/* Autogenerated file. Do not edit manually. */
/* tslint:disable */
/* eslint-disable */

import { Contract, Interface, type ContractRunner } from "ethers";
import type {
  IWETH,
  IWETHInterface,
} from "../../../contracts/UniswapV2Interfaces.sol/IWETH";

const _abi = [
  {
    inputs: [],
    name: "deposit",
    outputs: [],
    stateMutability: "payable",
    type: "function",
  },
  {
    inputs: [
      {
        internalType: "uint256",
        name: "",
        type: "uint256",
      },
    ],
    name: "withdraw",
    outputs: [],
    stateMutability: "nonpayable",
    type: "function",
  },
] as const;

export class IWETH__factory {
  static readonly abi = _abi;
  static createInterface(): IWETHInterface {
    return new Interface(_abi) as IWETHInterface;
  }
  static connect(address: string, runner?: ContractRunner | null): IWETH {
    return new Contract(address, _abi, runner) as unknown as IWETH;
  }
}
