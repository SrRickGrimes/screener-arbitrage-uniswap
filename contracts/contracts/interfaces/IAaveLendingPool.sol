// SPDX-License-Identifier: MIT

pragma solidity ^0.8.0;

interface IAaveLendingPool {
    function flashLoanFeePercentage() external view returns (uint256);
}
