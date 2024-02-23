import { ethers } from "hardhat";
import { expect } from "chai";
import {
  ArbitrageEstimator,
  MockUniswapRouter,
  MockAaveLendingPool,
} from "../typechain-types";

describe("ArbitrageEstimator", function () {
  let arbitrageEstimator: ArbitrageEstimator;
  let mockUniswapRouter: MockUniswapRouter;
  let mockSushiswapRouter: MockUniswapRouter;
  let mockAaveLendingPool: MockAaveLendingPool;

  beforeEach(async function () {
    const [owner] = await ethers.getSigners();

    const MockUniswapRouter = await ethers.getContractFactory(
      "MockUniswapRouter"
    );
    mockUniswapRouter = await MockUniswapRouter.deploy();
    mockSushiswapRouter = await MockUniswapRouter.deploy();

    const MockAaveLendingPool = await ethers.getContractFactory(
      "MockAaveLendingPool"
    );
    mockAaveLendingPool = await MockAaveLendingPool.deploy();

    const ArbitrageEstimator = await ethers.getContractFactory(
      "ArbitrageEstimator"
    );
    arbitrageEstimator = await ArbitrageEstimator.deploy(
      mockAaveLendingPool.getAddress()
    );

    // Configuración de valores de mock para este test
    await mockUniswapRouter.setAmountOut(ethers.parseUnits("1", "ether")); // 1 ETH
    await mockSushiswapRouter.setAmountOut(ethers.parseUnits("1.1", "ether")); // 1.1 ETH
  });

  it("Should only allow the owner to call estimateArbitrageProfitability", async function () {
    const [owner, addr1] = await ethers.getSigners();

    const tokenIn = "0x0000000000000000000000000000000000000000";
    const tokenOut = "0x0000000000000000000000000000000000000001";
    const amountIn = ethers.parseUnits("1", "ether");
    const estimatedGasCostWei = ethers.parseUnits("0.05", "ether");

    await expect(
      arbitrageEstimator
        .connect(addr1)
        .estimateArbitrageProfitability(
          mockUniswapRouter,
          mockSushiswapRouter,
          tokenIn,
          tokenOut,
          amountIn,
          estimatedGasCostWei
        )
    ).to.be.revertedWith("owner invalid");
  });
});
