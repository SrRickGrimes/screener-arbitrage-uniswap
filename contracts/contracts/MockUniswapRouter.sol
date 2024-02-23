// SPDX-License-Identifier: MIT

pragma solidity ^0.8.0;

contract MockUniswapRouter {
    uint public amountOut;
    
    function setAmountOut(uint _amountOut) external {
        amountOut = _amountOut;
    }

    function getAmountsOut(uint amountIn, address[] memory path) external view returns (uint[] memory amounts) {
        amounts = new uint[](2);
        amounts[0] = amountIn;
        amounts[1] = amountOut;
    }
}
