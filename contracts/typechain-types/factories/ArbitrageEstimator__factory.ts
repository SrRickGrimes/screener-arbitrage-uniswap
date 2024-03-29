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
import type { NonPayableOverrides } from "../common";
import type {
  ArbitrageEstimator,
  ArbitrageEstimatorInterface,
} from "../ArbitrageEstimator";

const _abi = [
  {
    inputs: [
      {
        internalType: "address",
        name: "_aaveLendingPoolAddress",
        type: "address",
      },
    ],
    stateMutability: "nonpayable",
    type: "constructor",
  },
  {
    inputs: [
      {
        internalType: "address",
        name: "routerA",
        type: "address",
      },
      {
        internalType: "address",
        name: "routerB",
        type: "address",
      },
      {
        internalType: "address",
        name: "tokenIn",
        type: "address",
      },
      {
        internalType: "address",
        name: "tokenOut",
        type: "address",
      },
      {
        internalType: "uint256",
        name: "amountIn",
        type: "uint256",
      },
      {
        internalType: "uint256",
        name: "estimatedGasCostWei",
        type: "uint256",
      },
    ],
    name: "estimateArbitrageProfitability",
    outputs: [
      {
        internalType: "uint256",
        name: "estimatedGasCost",
        type: "uint256",
      },
      {
        internalType: "uint256",
        name: "amountOutA",
        type: "uint256",
      },
      {
        internalType: "uint256",
        name: "amountOutB",
        type: "uint256",
      },
      {
        internalType: "int256",
        name: "potentialProfit",
        type: "int256",
      },
      {
        internalType: "int256",
        name: "profitabilityPercentage",
        type: "int256",
      },
    ],
    stateMutability: "view",
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
] as const;

const _bytecode =
  "0x60803461007a57601f61063c38819003918201601f19168301916001600160401b0383118484101761007f5780849260209460405283398101031261007a57516001600160a01b0381169081900361007a5760018060a01b03193381600054161760005560015416176001556040516105a690816100968239f35b600080fd5b634e487b7160e01b600052604160045260246000fdfe6040608081526004908136101561001557600080fd5b600091823560e01c80631615e705146100f55780638da5cb5b146100c95763f2fde38b1461004257600080fd5b346100c55760203660031901126100c55761005b6103c5565b835491906001600160a01b039061007533838616146103e0565b1692831561008f5750506001600160a01b03191617815580f35b906020606492519162461bcd60e51b8352820152601060248201526f4e6f2076616c6964206164647265737360801b6044820152fd5b8280fd5b5050346100f157816003193601126100f157905490516001600160a01b039091168152602090f35b5080fd5b5082346103be5760c03660031901126103be576101106103c5565b6024939092906001600160a01b03908535828116908190036103c157604435948386168096036103be576064358481168091036100f1576084359260a4359861015d8785541633146103e0565b8551926060840184811067ffffffffffffffff8211176103ac578752600284526020998a85018836823785511561039a57528895949392919061019f84610454565b528387518092818b816101c0898c63d06ca61f60e01b9e8f855284016104f6565b0392165afa9081156103905791896101e2879387958691610376575b50610454565b51976101f98a5196879586948594855284016104f6565b03915afa90811561036c5761021883928a928a959161034a5750610454565b51966001541686519384809263624cfc6760e11b82525afa91821561033e57819261030f575b50818302831592848204148317156102fd5761271061026b91046102668b610266888b610541565b610541565b96826102ef576064880292888405606414891517156102dd576102cb57600160ff1b83146000198514166102b957505060a0985005945b825196875286015284015260608301526080820152f35b634e487b7160e01b8252601190528990fd5b634e487b7160e01b8252601290528990fd5b634e487b7160e01b8352601182528b83fd5b5091505060a09750946102a2565b634e487b7160e01b8252601188528a82fd5b9091508781813d8311610337575b610327818361041c565b810103126100f15751908a61023e565b503d61031d565b508451903d90823e3d90fd5b61036691503d8086833e61035e818361041c565b81019061047a565b8d6101dc565b85513d84823e3d90fd5b61038a91503d8088833e61035e818361041c565b386101dc565b87513d86823e3d90fd5b634e487b7160e01b875260328b528d87fd5b634e487b7160e01b865260418a528c86fd5b80fd5b8480fd5b600435906001600160a01b03821682036103db57565b600080fd5b156103e757565b60405162461bcd60e51b815260206004820152600d60248201526c1bdddb995c881a5b9d985b1a59609a1b6044820152606490fd5b90601f8019910116810190811067ffffffffffffffff82111761043e57604052565b634e487b7160e01b600052604160045260246000fd5b8051600110156104645760400190565b634e487b7160e01b600052603260045260246000fd5b9060209081838203126103db57825167ffffffffffffffff938482116103db570181601f820112156103db57805193841161043e578360051b90604051946104c48584018761041c565b855283808601928201019283116103db578301905b8282106104e7575050505090565b815181529083019083016104d9565b906040820190825260206060819360408382015285518094520193019160005b828110610524575050505090565b83516001600160a01b031685529381019392810192600101610516565b8181039291600013801582851316918412161761055a57565b634e487b7160e01b600052601160045260246000fdfea2646970667358221220e6a00e7cac8eab347f3ec2756ca63b4737cd1074ccba56fe8fe0fbbb827bef4164736f6c63430008180033";

type ArbitrageEstimatorConstructorParams =
  | [signer?: Signer]
  | ConstructorParameters<typeof ContractFactory>;

const isSuperArgs = (
  xs: ArbitrageEstimatorConstructorParams
): xs is ConstructorParameters<typeof ContractFactory> => xs.length > 1;

export class ArbitrageEstimator__factory extends ContractFactory {
  constructor(...args: ArbitrageEstimatorConstructorParams) {
    if (isSuperArgs(args)) {
      super(...args);
    } else {
      super(_abi, _bytecode, args[0]);
    }
  }

  override getDeployTransaction(
    _aaveLendingPoolAddress: AddressLike,
    overrides?: NonPayableOverrides & { from?: string }
  ): Promise<ContractDeployTransaction> {
    return super.getDeployTransaction(_aaveLendingPoolAddress, overrides || {});
  }
  override deploy(
    _aaveLendingPoolAddress: AddressLike,
    overrides?: NonPayableOverrides & { from?: string }
  ) {
    return super.deploy(_aaveLendingPoolAddress, overrides || {}) as Promise<
      ArbitrageEstimator & {
        deploymentTransaction(): ContractTransactionResponse;
      }
    >;
  }
  override connect(runner: ContractRunner | null): ArbitrageEstimator__factory {
    return super.connect(runner) as ArbitrageEstimator__factory;
  }

  static readonly bytecode = _bytecode;
  static readonly abi = _abi;
  static createInterface(): ArbitrageEstimatorInterface {
    return new Interface(_abi) as ArbitrageEstimatorInterface;
  }
  static connect(
    address: string,
    runner?: ContractRunner | null
  ): ArbitrageEstimator {
    return new Contract(address, _abi, runner) as unknown as ArbitrageEstimator;
  }
}
