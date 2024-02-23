/* Autogenerated file. Do not edit manually. */
/* tslint:disable */
/* eslint-disable */

import { ethers } from "ethers";
import {
  DeployContractOptions,
  FactoryOptions,
  HardhatEthersHelpers as HardhatEthersHelpersBase,
} from "@nomicfoundation/hardhat-ethers/types";

import * as Contracts from ".";

declare module "hardhat/types/runtime" {
  interface HardhatEthersHelpers extends HardhatEthersHelpersBase {
    getContractFactory(
      name: "ArbitrageEstimator",
      signerOrOptions?: ethers.Signer | FactoryOptions
    ): Promise<Contracts.ArbitrageEstimator__factory>;
    getContractFactory(
      name: "IAaveLendingPool",
      signerOrOptions?: ethers.Signer | FactoryOptions
    ): Promise<Contracts.IAaveLendingPool__factory>;
    getContractFactory(
      name: "IUniswapV2Router",
      signerOrOptions?: ethers.Signer | FactoryOptions
    ): Promise<Contracts.IUniswapV2Router__factory>;
    getContractFactory(
      name: "Lock",
      signerOrOptions?: ethers.Signer | FactoryOptions
    ): Promise<Contracts.Lock__factory>;
    getContractFactory(
      name: "MockAaveLendingPool",
      signerOrOptions?: ethers.Signer | FactoryOptions
    ): Promise<Contracts.MockAaveLendingPool__factory>;
    getContractFactory(
      name: "MockUniswapRouter",
      signerOrOptions?: ethers.Signer | FactoryOptions
    ): Promise<Contracts.MockUniswapRouter__factory>;

    getContractAt(
      name: "ArbitrageEstimator",
      address: string | ethers.Addressable,
      signer?: ethers.Signer
    ): Promise<Contracts.ArbitrageEstimator>;
    getContractAt(
      name: "IAaveLendingPool",
      address: string | ethers.Addressable,
      signer?: ethers.Signer
    ): Promise<Contracts.IAaveLendingPool>;
    getContractAt(
      name: "IUniswapV2Router",
      address: string | ethers.Addressable,
      signer?: ethers.Signer
    ): Promise<Contracts.IUniswapV2Router>;
    getContractAt(
      name: "Lock",
      address: string | ethers.Addressable,
      signer?: ethers.Signer
    ): Promise<Contracts.Lock>;
    getContractAt(
      name: "MockAaveLendingPool",
      address: string | ethers.Addressable,
      signer?: ethers.Signer
    ): Promise<Contracts.MockAaveLendingPool>;
    getContractAt(
      name: "MockUniswapRouter",
      address: string | ethers.Addressable,
      signer?: ethers.Signer
    ): Promise<Contracts.MockUniswapRouter>;

    deployContract(
      name: "ArbitrageEstimator",
      signerOrOptions?: ethers.Signer | DeployContractOptions
    ): Promise<Contracts.ArbitrageEstimator>;
    deployContract(
      name: "IAaveLendingPool",
      signerOrOptions?: ethers.Signer | DeployContractOptions
    ): Promise<Contracts.IAaveLendingPool>;
    deployContract(
      name: "IUniswapV2Router",
      signerOrOptions?: ethers.Signer | DeployContractOptions
    ): Promise<Contracts.IUniswapV2Router>;
    deployContract(
      name: "Lock",
      signerOrOptions?: ethers.Signer | DeployContractOptions
    ): Promise<Contracts.Lock>;
    deployContract(
      name: "MockAaveLendingPool",
      signerOrOptions?: ethers.Signer | DeployContractOptions
    ): Promise<Contracts.MockAaveLendingPool>;
    deployContract(
      name: "MockUniswapRouter",
      signerOrOptions?: ethers.Signer | DeployContractOptions
    ): Promise<Contracts.MockUniswapRouter>;

    deployContract(
      name: "ArbitrageEstimator",
      args: any[],
      signerOrOptions?: ethers.Signer | DeployContractOptions
    ): Promise<Contracts.ArbitrageEstimator>;
    deployContract(
      name: "IAaveLendingPool",
      args: any[],
      signerOrOptions?: ethers.Signer | DeployContractOptions
    ): Promise<Contracts.IAaveLendingPool>;
    deployContract(
      name: "IUniswapV2Router",
      args: any[],
      signerOrOptions?: ethers.Signer | DeployContractOptions
    ): Promise<Contracts.IUniswapV2Router>;
    deployContract(
      name: "Lock",
      args: any[],
      signerOrOptions?: ethers.Signer | DeployContractOptions
    ): Promise<Contracts.Lock>;
    deployContract(
      name: "MockAaveLendingPool",
      args: any[],
      signerOrOptions?: ethers.Signer | DeployContractOptions
    ): Promise<Contracts.MockAaveLendingPool>;
    deployContract(
      name: "MockUniswapRouter",
      args: any[],
      signerOrOptions?: ethers.Signer | DeployContractOptions
    ): Promise<Contracts.MockUniswapRouter>;

    // default types
    getContractFactory(
      name: string,
      signerOrOptions?: ethers.Signer | FactoryOptions
    ): Promise<ethers.ContractFactory>;
    getContractFactory(
      abi: any[],
      bytecode: ethers.BytesLike,
      signer?: ethers.Signer
    ): Promise<ethers.ContractFactory>;
    getContractAt(
      nameOrAbi: string | any[],
      address: string | ethers.Addressable,
      signer?: ethers.Signer
    ): Promise<ethers.Contract>;
    deployContract(
      name: string,
      signerOrOptions?: ethers.Signer | DeployContractOptions
    ): Promise<ethers.Contract>;
    deployContract(
      name: string,
      args: any[],
      signerOrOptions?: ethers.Signer | DeployContractOptions
    ): Promise<ethers.Contract>;
  }
}
