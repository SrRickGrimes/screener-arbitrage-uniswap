// SPDX-License-Identifier: MIT

pragma solidity ^0.8.0;

import "./interfaces/IUniswapV2Router.sol";
import "./interfaces/IAaveLendingPool.sol";

contract ArbitrageEstimator {
    address public owner;
    IAaveLendingPool private aaveLendingPool;

    // Modificador para restringir el acceso solo al propietario
    modifier onlyOwner() {
        require(msg.sender == owner, "owner invalid");
        _;
    }

    constructor(address _aaveLendingPoolAddress) {
        owner = msg.sender; // Establece el propietario al desplegar el contrato
        aaveLendingPool = IAaveLendingPool(_aaveLendingPoolAddress);
    }

   
  function estimateArbitrageProfitability(
    address routerA,
    address routerB,
    address tokenIn,
    address tokenOut,
    uint amountIn,
    uint estimatedGasCostWei
) external view onlyOwner returns (uint estimatedGasCost, uint amountOutA, uint amountOutB, int potentialProfit, int profitabilityPercentage) {
    address[] memory path = new address[](2);
    path[0] = tokenIn;
    path[1] = tokenOut;

    // Estimación en DEX A
    uint[] memory amountsOutA = IUniswapV2Router(routerA).getAmountsOut(amountIn, path);
    amountOutA = amountsOutA[1];

    // Estimación en DEX B
    uint[] memory amountsOutB = IUniswapV2Router(routerB).getAmountsOut(amountIn, path);
    amountOutB = amountsOutB[1];

    // Obtén el porcentaje de fee de Aave (supongamos que es un valor como 0.09% = 0.0009 en forma decimal)
    uint256 aaveFeePercentage = aaveLendingPool.flashLoanFeePercentage(); // Esta función debe existir en IAaveLendingPool y devolver el fee como un uint256
    uint256 aaveFeeAmount = amountIn * aaveFeePercentage / 10000; // Suponiendo que aaveFeePercentage es un valor por 10,000 para representar decimales

    // Ajusta el cálculo de potentialProfit para restar el fee de Aave
    potentialProfit = int(amountOutB) - int(amountOutA) - int(estimatedGasCostWei) - int(aaveFeeAmount);

    // Calcula el porcentaje de rentabilidad
    if (amountIn > 0) {
        profitabilityPercentage = (potentialProfit * 100) / int(amountIn);
    } else {
        profitabilityPercentage = 0; // O manejar como un caso de error
    }

    return (estimatedGasCostWei, amountOutA, amountOutB, potentialProfit, profitabilityPercentage);
}


    // Función para transferir la propiedad del contrato
    function transferOwnership(address newOwner) public onlyOwner {
        require(newOwner != address(0), "No valid address");
        owner = newOwner;
    }
}
