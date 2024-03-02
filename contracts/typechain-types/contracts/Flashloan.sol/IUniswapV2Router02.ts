/* Autogenerated file. Do not edit manually. */
/* tslint:disable */
/* eslint-disable */
import type {
  BaseContract,
  BigNumberish,
  BytesLike,
  FunctionFragment,
  Result,
  Interface,
  AddressLike,
  ContractRunner,
  ContractMethod,
  Listener,
} from "ethers";
import type {
  TypedContractEvent,
  TypedDeferredTopicFilter,
  TypedEventLog,
  TypedListener,
  TypedContractMethod,
} from "../../common";

export interface IUniswapV2Router02Interface extends Interface {
  getFunction(
    nameOrSignature:
      | "WETH"
      | "addLiquidityETH"
      | "factory"
      | "getAmountsIn"
      | "getAmountsOut"
      | "quote"
      | "swapExactETHForTokens"
      | "swapExactTokensForETH"
      | "swapExactTokensForTokens"
  ): FunctionFragment;

  encodeFunctionData(functionFragment: "WETH", values?: undefined): string;
  encodeFunctionData(
    functionFragment: "addLiquidityETH",
    values: [
      AddressLike,
      BigNumberish,
      BigNumberish,
      BigNumberish,
      AddressLike,
      BigNumberish
    ]
  ): string;
  encodeFunctionData(functionFragment: "factory", values?: undefined): string;
  encodeFunctionData(
    functionFragment: "getAmountsIn",
    values: [BigNumberish, AddressLike[]]
  ): string;
  encodeFunctionData(
    functionFragment: "getAmountsOut",
    values: [BigNumberish, AddressLike[]]
  ): string;
  encodeFunctionData(
    functionFragment: "quote",
    values: [BigNumberish, BigNumberish, BigNumberish]
  ): string;
  encodeFunctionData(
    functionFragment: "swapExactETHForTokens",
    values: [BigNumberish, AddressLike[], AddressLike, BigNumberish]
  ): string;
  encodeFunctionData(
    functionFragment: "swapExactTokensForETH",
    values: [
      BigNumberish,
      BigNumberish,
      AddressLike[],
      AddressLike,
      BigNumberish
    ]
  ): string;
  encodeFunctionData(
    functionFragment: "swapExactTokensForTokens",
    values: [
      BigNumberish,
      BigNumberish,
      AddressLike[],
      AddressLike,
      BigNumberish
    ]
  ): string;

  decodeFunctionResult(functionFragment: "WETH", data: BytesLike): Result;
  decodeFunctionResult(
    functionFragment: "addLiquidityETH",
    data: BytesLike
  ): Result;
  decodeFunctionResult(functionFragment: "factory", data: BytesLike): Result;
  decodeFunctionResult(
    functionFragment: "getAmountsIn",
    data: BytesLike
  ): Result;
  decodeFunctionResult(
    functionFragment: "getAmountsOut",
    data: BytesLike
  ): Result;
  decodeFunctionResult(functionFragment: "quote", data: BytesLike): Result;
  decodeFunctionResult(
    functionFragment: "swapExactETHForTokens",
    data: BytesLike
  ): Result;
  decodeFunctionResult(
    functionFragment: "swapExactTokensForETH",
    data: BytesLike
  ): Result;
  decodeFunctionResult(
    functionFragment: "swapExactTokensForTokens",
    data: BytesLike
  ): Result;
}

export interface IUniswapV2Router02 extends BaseContract {
  connect(runner?: ContractRunner | null): IUniswapV2Router02;
  waitForDeployment(): Promise<this>;

  interface: IUniswapV2Router02Interface;

  queryFilter<TCEvent extends TypedContractEvent>(
    event: TCEvent,
    fromBlockOrBlockhash?: string | number | undefined,
    toBlock?: string | number | undefined
  ): Promise<Array<TypedEventLog<TCEvent>>>;
  queryFilter<TCEvent extends TypedContractEvent>(
    filter: TypedDeferredTopicFilter<TCEvent>,
    fromBlockOrBlockhash?: string | number | undefined,
    toBlock?: string | number | undefined
  ): Promise<Array<TypedEventLog<TCEvent>>>;

  on<TCEvent extends TypedContractEvent>(
    event: TCEvent,
    listener: TypedListener<TCEvent>
  ): Promise<this>;
  on<TCEvent extends TypedContractEvent>(
    filter: TypedDeferredTopicFilter<TCEvent>,
    listener: TypedListener<TCEvent>
  ): Promise<this>;

  once<TCEvent extends TypedContractEvent>(
    event: TCEvent,
    listener: TypedListener<TCEvent>
  ): Promise<this>;
  once<TCEvent extends TypedContractEvent>(
    filter: TypedDeferredTopicFilter<TCEvent>,
    listener: TypedListener<TCEvent>
  ): Promise<this>;

  listeners<TCEvent extends TypedContractEvent>(
    event: TCEvent
  ): Promise<Array<TypedListener<TCEvent>>>;
  listeners(eventName?: string): Promise<Array<Listener>>;
  removeAllListeners<TCEvent extends TypedContractEvent>(
    event?: TCEvent
  ): Promise<this>;

  WETH: TypedContractMethod<[], [string], "view">;

  addLiquidityETH: TypedContractMethod<
    [
      token: AddressLike,
      amountTokenDesired: BigNumberish,
      amountTokenMin: BigNumberish,
      amountETHMin: BigNumberish,
      to: AddressLike,
      deadline: BigNumberish
    ],
    [
      [bigint, bigint, bigint] & {
        amountToken: bigint;
        amountETH: bigint;
        liquidity: bigint;
      }
    ],
    "payable"
  >;

  factory: TypedContractMethod<[], [string], "view">;

  getAmountsIn: TypedContractMethod<
    [amountOut: BigNumberish, path: AddressLike[]],
    [bigint[]],
    "view"
  >;

  getAmountsOut: TypedContractMethod<
    [amountIn: BigNumberish, path: AddressLike[]],
    [bigint[]],
    "view"
  >;

  quote: TypedContractMethod<
    [amountA: BigNumberish, reserveA: BigNumberish, reserveB: BigNumberish],
    [bigint],
    "view"
  >;

  swapExactETHForTokens: TypedContractMethod<
    [
      amountOutMin: BigNumberish,
      path: AddressLike[],
      to: AddressLike,
      deadline: BigNumberish
    ],
    [bigint[]],
    "payable"
  >;

  swapExactTokensForETH: TypedContractMethod<
    [
      amountIn: BigNumberish,
      amountOutMin: BigNumberish,
      path: AddressLike[],
      to: AddressLike,
      deadline: BigNumberish
    ],
    [bigint[]],
    "nonpayable"
  >;

  swapExactTokensForTokens: TypedContractMethod<
    [
      amountIn: BigNumberish,
      amountOutMin: BigNumberish,
      path: AddressLike[],
      to: AddressLike,
      deadline: BigNumberish
    ],
    [bigint[]],
    "nonpayable"
  >;

  getFunction<T extends ContractMethod = ContractMethod>(
    key: string | FunctionFragment
  ): T;

  getFunction(
    nameOrSignature: "WETH"
  ): TypedContractMethod<[], [string], "view">;
  getFunction(
    nameOrSignature: "addLiquidityETH"
  ): TypedContractMethod<
    [
      token: AddressLike,
      amountTokenDesired: BigNumberish,
      amountTokenMin: BigNumberish,
      amountETHMin: BigNumberish,
      to: AddressLike,
      deadline: BigNumberish
    ],
    [
      [bigint, bigint, bigint] & {
        amountToken: bigint;
        amountETH: bigint;
        liquidity: bigint;
      }
    ],
    "payable"
  >;
  getFunction(
    nameOrSignature: "factory"
  ): TypedContractMethod<[], [string], "view">;
  getFunction(
    nameOrSignature: "getAmountsIn"
  ): TypedContractMethod<
    [amountOut: BigNumberish, path: AddressLike[]],
    [bigint[]],
    "view"
  >;
  getFunction(
    nameOrSignature: "getAmountsOut"
  ): TypedContractMethod<
    [amountIn: BigNumberish, path: AddressLike[]],
    [bigint[]],
    "view"
  >;
  getFunction(
    nameOrSignature: "quote"
  ): TypedContractMethod<
    [amountA: BigNumberish, reserveA: BigNumberish, reserveB: BigNumberish],
    [bigint],
    "view"
  >;
  getFunction(
    nameOrSignature: "swapExactETHForTokens"
  ): TypedContractMethod<
    [
      amountOutMin: BigNumberish,
      path: AddressLike[],
      to: AddressLike,
      deadline: BigNumberish
    ],
    [bigint[]],
    "payable"
  >;
  getFunction(
    nameOrSignature: "swapExactTokensForETH"
  ): TypedContractMethod<
    [
      amountIn: BigNumberish,
      amountOutMin: BigNumberish,
      path: AddressLike[],
      to: AddressLike,
      deadline: BigNumberish
    ],
    [bigint[]],
    "nonpayable"
  >;
  getFunction(
    nameOrSignature: "swapExactTokensForTokens"
  ): TypedContractMethod<
    [
      amountIn: BigNumberish,
      amountOutMin: BigNumberish,
      path: AddressLike[],
      to: AddressLike,
      deadline: BigNumberish
    ],
    [bigint[]],
    "nonpayable"
  >;

  filters: {};
}