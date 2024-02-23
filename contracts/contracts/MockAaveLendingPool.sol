// SPDX-License-Identifier: MIT

pragma solidity ^0.8.0;

contract MockAaveLendingPool {
    uint256 private feePercentage;

    function setFlashLoanFeePercentage(uint256 _feePercentage) external {
        feePercentage = _feePercentage;
    }

    function flashLoanFeePercentage() external view returns (uint256) {
        return feePercentage;
    }
}
