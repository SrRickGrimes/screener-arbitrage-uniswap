// SPDX-License-Identifier: MIT

pragma solidity ^0.8.0;

interface IUniswapV2Router02 {
    function swapExactTokensForTokens(
        uint amountIn,
        uint amountOutMin,
        address[] calldata path,
        address to,
        uint deadline
    ) external returns (uint[] memory amounts);
    function getAmountsIn(uint amountOut, address[] calldata path) external view returns (uint[] memory amounts);
    function getAmountsOut(uint amountIn, address[] calldata path) external view returns (uint[] memory amounts);
    function factory() external view returns (address);
    function WETH() external view returns (address);
    function quote(uint amountA, uint reserveA, uint reserveB) external pure returns (uint amountB);
    function addLiquidityETH(address token,uint amountTokenDesired,uint amountTokenMin,uint amountETHMin,address to,uint deadline) external payable returns (uint amountToken, uint amountETH, uint liquidity);
    function swapExactTokensForETH(uint amountIn, uint amountOutMin, address[] calldata path, address to, uint deadline) external returns (uint[] memory amounts);
    function swapExactETHForTokens(uint amountOutMin, address[] calldata path, address to, uint deadline) external payable returns (uint[] memory amounts);
}

interface IERC20 {
    function approve(address spender, uint256 amount) external returns (bool);
    function transferFrom(address sender, address recipient, uint256 amount) external returns (bool);
    function balanceOf(address account) external view returns (uint256);
    function transfer(address recipient, uint256 amount) external returns (bool);
    function allowance(address owner, address spender) external view returns (uint256);
}

contract UniswapV2FlashSwap {
    address public immutable factory;
    address public immutable WETH;
    address public owner;

    address public constant UNISWAP_V2_ROUTER = 0x7a250d5630B4cF539739dF2C5dAcb4c659F2488D;

    constructor(address _factory, address _WETH) {
        factory = _factory;
        WETH = _WETH;
        owner = msg.sender;
    }

    receive() external payable {}

    function uniswapV2Call(address, uint, uint, bytes calldata) external {}

    function initiateFlashSwap(address _tokenIn,  uint256 _amountIn,  address _tokenOut, address _targetToken, uint256 _amountOutMin) external payable {
        require(msg.sender == owner, "UniswapV2FlashSwap: caller is not the owner");

        uint256 profit = 0;
        while (true) {
            // Calculate the amount of tokens to borrow
            uint256 amountToBorrow = IUniswapV2Router02(UNISWAP_V2_ROUTER).getAmountsIn(_amountOutMin + profit, getPath(_tokenOut, _tokenIn))[0];

            IERC20(_tokenIn).approve(UNISWAP_V2_ROUTER, amountToBorrow);

            // Borrow tokens from Uniswap using flash loan
            address[] memory path = getPath(WETH, _tokenIn);
            IUniswapV2Router02(UNISWAP_V2_ROUTER).swapExactETHForTokens{value: amountToBorrow}(
                amountToBorrow,
                path,
                address(this),
                block.timestamp
            );

        // Swap borrowed tokens for target token
        path = getPath(_tokenIn, _targetToken);
        uint[] memory amounts = IUniswapV2Router02(UNISWAP_V2_ROUTER).swapExactTokensForTokens(
            IERC20(_tokenIn).balanceOf(address(this)),
            _amountOutMin,
            path,
            address(this),
            block.timestamp
        );


                      // Calculate profit and check if it's greater than zero
        profit = amounts[amounts.length - 1] - (_amountOutMin + profit);
        require(profit > 0, "UniswapV2FlashSwap: insufficient profit");

        // Swap target tokens for borrowed tokens
        IERC20(_targetToken).approve(UNISWAP_V2_ROUTER, amounts[amounts.length - 1]);
        IUniswapV2Router02(UNISWAP_V2_ROUTER).swapExactTokensForTokens(
            amounts[amounts.length - 1],
            0,
            getPath(_targetToken, _tokenIn),
            address(this),
            block.timestamp
        );

        // Repay flash loan
        IERC20(_tokenIn).transfer(msg.sender, amountToBorrow);

        // Check if target token balance is greater than or equal to requested amountOutMin
        if (IERC20(_targetToken).balanceOf(address(this)) >= _amountOutMin) {
            // Transfer target tokens to the caller
            IERC20(_targetToken).transfer(msg.sender, IERC20(_targetToken).balanceOf(address(this)));
            break;
        }
    }
}

function getPath(address _tokenIn, address _tokenOut) private view returns (address[] memory path) {
    if (_tokenIn == WETH || _tokenOut == WETH) {
        path = new address[](2);
        path[0] = _tokenIn;
        path[1] = _tokenOut;
    } else {
        path = new address[](3);
        path[0] = _tokenIn;
        path[1] = WETH;
        path[2] = _tokenOut;
    }
}

function transferOwnership(address newOwner) external {
    require(msg.sender == owner, "UniswapV2FlashSwap: caller is not the owner");
    owner = newOwner;
}

function withdrawToken(address token, uint256 amount) external {
    require(msg.sender == owner, "UniswapV2FlashSwap: caller is not the owner");
    IERC20(token).transfer(msg.sender, amount);
}

function withdrawETH(uint256 amount) external {
    require(msg.sender == owner, "UniswapV2FlashSwap: caller is not the owner");
    payable(msg.sender).transfer(amount);
}
}