/* Autogenerated file. Do not edit manually. */
/* tslint:disable */
/* eslint-disable */
import {
  Contract,
  ContractFactory,
  ContractTransactionResponse,
  Interface,
} from "ethers";
import type { Signer, ContractDeployTransaction, ContractRunner } from "ethers";
import type { NonPayableOverrides } from "../common";
import type {
  MockAaveLendingPool,
  MockAaveLendingPoolInterface,
} from "../MockAaveLendingPool";

const _abi = [
  {
    inputs: [],
    name: "flashLoanFeePercentage",
    outputs: [
      {
        internalType: "uint256",
        name: "",
        type: "uint256",
      },
    ],
    stateMutability: "view",
    type: "function",
  },
  {
    inputs: [
      {
        internalType: "uint256",
        name: "_feePercentage",
        type: "uint256",
      },
    ],
    name: "setFlashLoanFeePercentage",
    outputs: [],
    stateMutability: "nonpayable",
    type: "function",
  },
] as const;

const _bytecode =
  "0x60808060405234601457609d908161001a8239f35b600080fdfe6080806040526004361015601257600080fd5b600090813560e01c80636b6b9f6914604c5763c499f8ce14603257600080fd5b3460485781600319360112604857602091548152f35b5080fd5b82346064576020366003190112606457600435815580f35b80fdfea2646970667358221220dac3774194d474e8c99a3ea3b0e1b0e9d4cf3eb984a0a16117e5e5aa88e59eb264736f6c63430008180033";

type MockAaveLendingPoolConstructorParams =
  | [signer?: Signer]
  | ConstructorParameters<typeof ContractFactory>;

const isSuperArgs = (
  xs: MockAaveLendingPoolConstructorParams
): xs is ConstructorParameters<typeof ContractFactory> => xs.length > 1;

export class MockAaveLendingPool__factory extends ContractFactory {
  constructor(...args: MockAaveLendingPoolConstructorParams) {
    if (isSuperArgs(args)) {
      super(...args);
    } else {
      super(_abi, _bytecode, args[0]);
    }
  }

  override getDeployTransaction(
    overrides?: NonPayableOverrides & { from?: string }
  ): Promise<ContractDeployTransaction> {
    return super.getDeployTransaction(overrides || {});
  }
  override deploy(overrides?: NonPayableOverrides & { from?: string }) {
    return super.deploy(overrides || {}) as Promise<
      MockAaveLendingPool & {
        deploymentTransaction(): ContractTransactionResponse;
      }
    >;
  }
  override connect(
    runner: ContractRunner | null
  ): MockAaveLendingPool__factory {
    return super.connect(runner) as MockAaveLendingPool__factory;
  }

  static readonly bytecode = _bytecode;
  static readonly abi = _abi;
  static createInterface(): MockAaveLendingPoolInterface {
    return new Interface(_abi) as MockAaveLendingPoolInterface;
  }
  static connect(
    address: string,
    runner?: ContractRunner | null
  ): MockAaveLendingPool {
    return new Contract(
      address,
      _abi,
      runner
    ) as unknown as MockAaveLendingPool;
  }
}
