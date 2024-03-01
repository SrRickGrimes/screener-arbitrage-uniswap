/* Autogenerated file. Do not edit manually. */
/* tslint:disable */
/* eslint-disable */
import {
  Contract,
  ContractFactory,
  ContractTransactionResponse,
  Interface,
} from "ethers";
import type {
  Signer,
  AddressLike,
  ContractDeployTransaction,
  ContractRunner,
} from "ethers";
import type { NonPayableOverrides } from "../../../common";
import type {
  UniswapV2FlashSwap,
  UniswapV2FlashSwapInterface,
} from "../../../contracts/Flashloan.sol/UniswapV2FlashSwap";

const _abi = [
  {
    inputs: [
      {
        internalType: "address",
        name: "_factory",
        type: "address",
      },
      {
        internalType: "address",
        name: "_WETH",
        type: "address",
      },
    ],
    stateMutability: "nonpayable",
    type: "constructor",
  },
  {
    inputs: [],
    name: "UNISWAP_V2_ROUTER",
    outputs: [
      {
        internalType: "address",
        name: "",
        type: "address",
      },
    ],
    stateMutability: "view",
    type: "function",
  },
  {
    inputs: [],
    name: "WETH",
    outputs: [
      {
        internalType: "address",
        name: "",
        type: "address",
      },
    ],
    stateMutability: "view",
    type: "function",
  },
  {
    inputs: [],
    name: "factory",
    outputs: [
      {
        internalType: "address",
        name: "",
        type: "address",
      },
    ],
    stateMutability: "view",
    type: "function",
  },
  {
    inputs: [
      {
        internalType: "address",
        name: "_tokenIn",
        type: "address",
      },
      {
        internalType: "uint256",
        name: "_amountIn",
        type: "uint256",
      },
      {
        internalType: "address",
        name: "_tokenOut",
        type: "address",
      },
      {
        internalType: "address",
        name: "_targetToken",
        type: "address",
      },
      {
        internalType: "uint256",
        name: "_amountOutMin",
        type: "uint256",
      },
    ],
    name: "initiateFlashSwap",
    outputs: [],
    stateMutability: "payable",
    type: "function",
  },
  {
    inputs: [],
    name: "owner",
    outputs: [
      {
        internalType: "address",
        name: "",
        type: "address",
      },
    ],
    stateMutability: "view",
    type: "function",
  },
  {
    inputs: [
      {
        internalType: "address",
        name: "newOwner",
        type: "address",
      },
    ],
    name: "transferOwnership",
    outputs: [],
    stateMutability: "nonpayable",
    type: "function",
  },
  {
    inputs: [
      {
        internalType: "address",
        name: "",
        type: "address",
      },
      {
        internalType: "uint256",
        name: "",
        type: "uint256",
      },
      {
        internalType: "uint256",
        name: "",
        type: "uint256",
      },
      {
        internalType: "bytes",
        name: "",
        type: "bytes",
      },
    ],
    name: "uniswapV2Call",
    outputs: [],
    stateMutability: "nonpayable",
    type: "function",
  },
  {
    inputs: [
      {
        internalType: "uint256",
        name: "amount",
        type: "uint256",
      },
    ],
    name: "withdrawETH",
    outputs: [],
    stateMutability: "nonpayable",
    type: "function",
  },
  {
    inputs: [
      {
        internalType: "address",
        name: "token",
        type: "address",
      },
      {
        internalType: "uint256",
        name: "amount",
        type: "uint256",
      },
    ],
    name: "withdrawToken",
    outputs: [],
    stateMutability: "nonpayable",
    type: "function",
  },
  {
    stateMutability: "payable",
    type: "receive",
  },
] as const;

const _bytecode =
  "0x60c03461009c57601f610cc938819003918201601f19168301916001600160401b038311848410176100a157808492604094855283398101031261009c57610052602061004b836100b7565b92016100b7565b60809190915260a052600080546001600160a01b03191633179055604051610bfd90816100cc823960805181610139015260a05181818161017e015281816103f90152610af10152f35b600080fd5b634e487b7160e01b600052604160045260246000fd5b51906001600160a01b038216820361009c5756fe6080604052600436101561001b575b361561001957600080fd5b005b60003560e01c80630c2a9bef146102e757806310d1e85c146102965780638da5cb5b1461026d5780639e281a98146101dc578063a82ed9ec146101ad578063ad5c464814610168578063c45a015514610123578063f14210a6146100cf5763f2fde38b0361000e57346100ca5760203660031901126100ca5761009c61090e565b600054906001600160a01b03906100b63383851614610924565b6001600160a01b0319909216911617600055005b600080fd5b346100ca5760203660031901126100ca5760008080806004356100fc60018060a01b038354163314610924565b81811561011a575b3390f11561010e57005b6040513d6000823e3d90fd5b506108fc610104565b346100ca5760003660031901126100ca576040517f00000000000000000000000000000000000000000000000000000000000000006001600160a01b03168152602090f35b346100ca5760003660031901126100ca576040517f00000000000000000000000000000000000000000000000000000000000000006001600160a01b03168152602090f35b346100ca5760003660031901126100ca576020604051737a250d5630b4cf539739df2c5dacb4c659f2488d8152f35b346100ca5760403660031901126100ca57600060206101f961090e565b82546001600160a01b0391906102129083163314610924565b60405163a9059cbb60e01b81523360048201526024803590820152938492604492849291165af1801561010e5761024557005b6100199060203d602011610266575b61025e8183610991565b810190610ac9565b503d610254565b346100ca5760003660031901126100ca576000546040516001600160a01b039091168152602090f35b346100ca5760803660031901126100ca576102af61090e565b5060643567ffffffffffffffff8082116100ca57366023830112156100ca5781600401359081116100ca57369101602401116100ca57005b60a03660031901126100ca576102fb61090e565b6001600160a01b039060443580831690036100ca578160643516606435036100ca5761032c82600054163314610924565b60005b610375600061034083608435610984565b61034c85604435610ae1565b9060405193849283926307c0329d60e21b84526004840152604060248401526044830190610a45565b0381737a250d5630b4cf539739df2c5dacb4c659f2488d5afa801561010e576103a6916000916108f3575b50610a82565b5160405163095ea7b360e01b8152737a250d5630b4cf539739df2c5dacb4c659f2488d6004820152602481018290526020816044816000888a165af1801561010e576108d4575b50610445600061041d857f0000000000000000000000000000000000000000000000000000000000000000610ae1565b60405180938192637ff36ab560e01b8352866004840152608060248401526084830190610a45565b306044830152426064830152038185737a250d5630b4cf539739df2c5dacb4c659f2488d5af1801561010e576108b9575b5061048360643584610ae1565b906040516370a0823160e01b81523060048201526020816024818989165afa90811561010e57600091610885575b506104e99260009160405194859283926338ed173960e01b84526004840152608435602484015260a0604484015260a4830190610a45565b306064830152426084830152038183737a250d5630b4cf539739df2c5dacb4c659f2488d5af191821561010e57600092610868575b508151806000198101116107de5761053d610547916000190184610ab5565b5193608435610984565b8084038481116107de579314610813578151806000198101116107de57610572906000190183610ab5565b516040519063095ea7b360e01b8252737a250d5630b4cf539739df2c5dacb4c659f2488d6004830152602482015260208160448160008a606435165af1801561010e576107f4575b50815191826000198101116107de576105dc6000916106189483190190610ab5565b516105e986606435610ae1565b9060405194859283926338ed173960e01b8452600484015284602484015260a0604484015260a4830190610a45565b306064830152426084830152038183737a250d5630b4cf539739df2c5dacb4c659f2488d5af190811561010e57610679926020926107bb575b5060405163a9059cbb60e01b8152336004820152602481019190915291829081906044820190565b038160008888165af1801561010e5761079c575b506040516370a0823160e01b815230600482015260208160248160643588165afa90811561010e5760009161076a575b506084351161032f576040516370a0823160e01b81523060048201528360208260248160643585165afa91821561010e57600092610734575b5060405163a9059cbb60e01b81523360048201526024810192909252602090829081600081604481015b0392606435165af1801561010e5761024557005b91506020823d602011610762575b8161074f60209383610991565b810103126100ca579051906107206106f6565b3d9150610742565b90506020813d602011610794575b8161078560209383610991565b810103126100ca5751846106bd565b3d9150610778565b6107b49060203d6020116102665761025e8183610991565b508361068d565b6107d7903d806000833e6107cf8183610991565b8101906109c9565b5086610651565b634e487b7160e01b600052601160045260246000fd5b61080c9060203d6020116102665761025e8183610991565b50856105ba565b60405162461bcd60e51b815260206004820152602760248201527f556e69737761705632466c617368537761703a20696e73756666696369656e74604482015266081c1c9bd99a5d60ca1b6064820152608490fd5b61087e9192503d806000833e6107cf8183610991565b908561051e565b90506020813d6020116108b1575b816108a060209383610991565b810103126100ca57516104e96104b1565b3d9150610893565b6108cd903d806000833e6107cf8183610991565b5084610476565b6108ec9060203d6020116102665761025e8183610991565b50846103ed565b61090891503d806000833e6107cf8183610991565b856103a0565b600435906001600160a01b03821682036100ca57565b1561092b57565b60405162461bcd60e51b815260206004820152602b60248201527f556e69737761705632466c617368537761703a2063616c6c6572206973206e6f60448201526a3a103a34329037bbb732b960a91b6064820152608490fd5b919082018092116107de57565b90601f8019910116810190811067ffffffffffffffff8211176109b357604052565b634e487b7160e01b600052604160045260246000fd5b9060209081838203126100ca57825167ffffffffffffffff938482116100ca570181601f820112156100ca5780519384116109b3578360051b9060405194610a1385840187610991565b855283808601928201019283116100ca578301905b828210610a36575050505090565b81518152908301908301610a28565b90815180825260208080930193019160005b828110610a65575050505090565b83516001600160a01b031685529381019392810192600101610a57565b805115610a8f5760200190565b634e487b7160e01b600052603260045260246000fd5b805160011015610a8f5760400190565b8051821015610a8f5760209160051b010190565b908160209103126100ca575180151581036100ca5790565b6001600160a01b039081169291907f000000000000000000000000000000000000000000000000000000000000000081168481148015610bbc575b15610b675750604051606081019080821067ffffffffffffffff8311176109b357610b61916040526002815260403660208301378095610b5b82610a82565b52610aa5565b91169052565b9190604051926080840184811067ffffffffffffffff8211176109b3576040526003845260603660208601378395610b9e85610a82565b52610ba884610aa5565b52825160021015610a8f5760609116910152565b508082841614610b1c56fea26469706673582212200fdeadece1a496118fe422cd1b65f5a429cb444e78ba3d482d4d958d7edb3ff064736f6c63430008180033";

type UniswapV2FlashSwapConstructorParams =
  | [signer?: Signer]
  | ConstructorParameters<typeof ContractFactory>;

const isSuperArgs = (
  xs: UniswapV2FlashSwapConstructorParams
): xs is ConstructorParameters<typeof ContractFactory> => xs.length > 1;

export class UniswapV2FlashSwap__factory extends ContractFactory {
  constructor(...args: UniswapV2FlashSwapConstructorParams) {
    if (isSuperArgs(args)) {
      super(...args);
    } else {
      super(_abi, _bytecode, args[0]);
    }
  }

  override getDeployTransaction(
    _factory: AddressLike,
    _WETH: AddressLike,
    overrides?: NonPayableOverrides & { from?: string }
  ): Promise<ContractDeployTransaction> {
    return super.getDeployTransaction(_factory, _WETH, overrides || {});
  }
  override deploy(
    _factory: AddressLike,
    _WETH: AddressLike,
    overrides?: NonPayableOverrides & { from?: string }
  ) {
    return super.deploy(_factory, _WETH, overrides || {}) as Promise<
      UniswapV2FlashSwap & {
        deploymentTransaction(): ContractTransactionResponse;
      }
    >;
  }
  override connect(runner: ContractRunner | null): UniswapV2FlashSwap__factory {
    return super.connect(runner) as UniswapV2FlashSwap__factory;
  }

  static readonly bytecode = _bytecode;
  static readonly abi = _abi;
  static createInterface(): UniswapV2FlashSwapInterface {
    return new Interface(_abi) as UniswapV2FlashSwapInterface;
  }
  static connect(
    address: string,
    runner?: ContractRunner | null
  ): UniswapV2FlashSwap {
    return new Contract(address, _abi, runner) as unknown as UniswapV2FlashSwap;
  }
}
