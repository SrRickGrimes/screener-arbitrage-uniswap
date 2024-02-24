// SPDX-License-Identifier: MIT

pragma solidity ^0.8.0;

import "./interfaces/IUniswapV2Router.sol";
import "./interfaces/IAaveLendingPool.sol";

contract ArbitrageEstimator {
    address public owner;
    IAaveLendingPool private aaveLendingPool;

    modifier onlyOwner() {
        require(msg.sender == owner, "owner invalid");
        _;
    }

    constructor(address _aaveLendingPoolAddress) {
        owner = msg.sender;
        aaveLendingPool = IAaveLendingPool(_aaveLendingPoolAddress);
    }

    function estimateArbitrageProfitability(
        address routerA,
        address routerB,
        address tokenIn,
        address tokenOut,
        uint amountIn,
        uint estimatedGasCostWei
    )
        external
        view
        onlyOwner
        returns (
            uint estimatedGasCost,
            uint amountOutA,
            uint amountOutB,
            int potentialProfit,
            int profitabilityPercentage
        )
    {
        address[] memory path = new address[](2);
        path[0] = tokenIn;
        path[1] = tokenOut;

        uint[] memory amountsOutA = IUniswapV2Router(routerA).getAmountsOut(
            amountIn,
            path
        );
        amountOutA = amountsOutA[1];

        uint[] memory amountsOutB = IUniswapV2Router(routerB).getAmountsOut(
            amountIn,
            path
        );
        amountOutB = amountsOutB[1];

        uint256 aaveFeePercentage = aaveLendingPool.flashLoanFeePercentage();
        uint256 aaveFeeAmount = (amountIn * aaveFeePercentage) / 10000;

        potentialProfit =
            int(amountOutB) -
            int(amountOutA) -
            int(estimatedGasCostWei) -
            int(aaveFeeAmount);

        if (amountIn > 0) {
            profitabilityPercentage = (potentialProfit * 100) / int(amountIn);
        } else {
            profitabilityPercentage = 0;
        }

        return (
            estimatedGasCostWei,
            amountOutA,
            amountOutB,
            potentialProfit,
            profitabilityPercentage
        );
    }

    function transferOwnership(address newOwner) public onlyOwner {
        require(newOwner != address(0), "No valid address");
        owner = newOwner;
    }
}
