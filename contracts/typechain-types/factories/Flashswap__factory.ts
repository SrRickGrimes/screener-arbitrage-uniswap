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
import type { Flashswap, FlashswapInterface } from "../Flashswap";

const _abi = [
  {
    inputs: [],
    stateMutability: "nonpayable",
    type: "constructor",
  },
  {
    inputs: [
      {
        internalType: "address",
        name: "_sender",
        type: "address",
      },
      {
        internalType: "uint256",
        name: "_amount0",
        type: "uint256",
      },
      {
        internalType: "uint256",
        name: "_amount1",
        type: "uint256",
      },
      {
        internalType: "bytes",
        name: "_data",
        type: "bytes",
      },
    ],
    name: "BiswapCall",
    outputs: [],
    stateMutability: "nonpayable",
    type: "function",
  },
  {
    inputs: [
      {
        internalType: "address",
        name: "_sender",
        type: "address",
      },
      {
        internalType: "uint256",
        name: "_amount0",
        type: "uint256",
      },
      {
        internalType: "uint256",
        name: "_amount1",
        type: "uint256",
      },
      {
        internalType: "bytes",
        name: "_data",
        type: "bytes",
      },
    ],
    name: "cafeCall",
    outputs: [],
    stateMutability: "nonpayable",
    type: "function",
  },
  {
    inputs: [
      {
        internalType: "address",
        name: "_tokenBorrow",
        type: "address",
      },
      {
        internalType: "uint256",
        name: "_amountTokenPay",
        type: "uint256",
      },
      {
        internalType: "address",
        name: "_tokenPay",
        type: "address",
      },
      {
        internalType: "address",
        name: "_sourceRouter",
        type: "address",
      },
      {
        internalType: "address",
        name: "_targetRouter",
        type: "address",
      },
    ],
    name: "check",
    outputs: [
      {
        internalType: "int256",
        name: "",
        type: "int256",
      },
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
        internalType: "address",
        name: "_sender",
        type: "address",
      },
      {
        internalType: "uint256",
        name: "_amount0",
        type: "uint256",
      },
      {
        internalType: "uint256",
        name: "_amount1",
        type: "uint256",
      },
      {
        internalType: "bytes",
        name: "_data",
        type: "bytes",
      },
    ],
    name: "jetswapCall",
    outputs: [],
    stateMutability: "nonpayable",
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
        name: "_sender",
        type: "address",
      },
      {
        internalType: "uint256",
        name: "_amount0",
        type: "uint256",
      },
      {
        internalType: "uint256",
        name: "_amount1",
        type: "uint256",
      },
      {
        internalType: "bytes",
        name: "_data",
        type: "bytes",
      },
    ],
    name: "pancakeCall",
    outputs: [],
    stateMutability: "nonpayable",
    type: "function",
  },
  {
    inputs: [
      {
        internalType: "address",
        name: "_sender",
        type: "address",
      },
      {
        internalType: "uint256",
        name: "_amount0",
        type: "uint256",
      },
      {
        internalType: "uint256",
        name: "_amount1",
        type: "uint256",
      },
      {
        internalType: "bytes",
        name: "_data",
        type: "bytes",
      },
    ],
    name: "pantherCall",
    outputs: [],
    stateMutability: "nonpayable",
    type: "function",
  },
  {
    inputs: [
      {
        internalType: "uint256",
        name: "_maxBlockNumber",
        type: "uint256",
      },
      {
        internalType: "address",
        name: "_tokenBorrow",
        type: "address",
      },
      {
        internalType: "uint256",
        name: "_amountTokenPay",
        type: "uint256",
      },
      {
        internalType: "address",
        name: "_tokenPay",
        type: "address",
      },
      {
        internalType: "address",
        name: "_sourceRouter",
        type: "address",
      },
      {
        internalType: "address",
        name: "_targetRouter",
        type: "address",
      },
      {
        internalType: "address",
        name: "_sourceFactory",
        type: "address",
      },
    ],
    name: "start",
    outputs: [],
    stateMutability: "nonpayable",
    type: "function",
  },
  {
    inputs: [
      {
        internalType: "address",
        name: "_sender",
        type: "address",
      },
      {
        internalType: "uint256",
        name: "_amount0",
        type: "uint256",
      },
      {
        internalType: "uint256",
        name: "_amount1",
        type: "uint256",
      },
      {
        internalType: "bytes",
        name: "_data",
        type: "bytes",
      },
    ],
    name: "swapV2Call",
    outputs: [],
    stateMutability: "nonpayable",
    type: "function",
  },
  {
    inputs: [
      {
        internalType: "address",
        name: "_sender",
        type: "address",
      },
      {
        internalType: "uint256",
        name: "_amount0",
        type: "uint256",
      },
      {
        internalType: "uint256",
        name: "_amount1",
        type: "uint256",
      },
      {
        internalType: "bytes",
        name: "_data",
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
        internalType: "address",
        name: "_sender",
        type: "address",
      },
      {
        internalType: "uint256",
        name: "_amount0",
        type: "uint256",
      },
      {
        internalType: "uint256",
        name: "_amount1",
        type: "uint256",
      },
      {
        internalType: "bytes",
        name: "_data",
        type: "bytes",
      },
    ],
    name: "wardenCall",
    outputs: [],
    stateMutability: "nonpayable",
    type: "function",
  },
  {
    inputs: [
      {
        internalType: "address",
        name: "_sender",
        type: "address",
      },
      {
        internalType: "uint256",
        name: "_amount0",
        type: "uint256",
      },
      {
        internalType: "uint256",
        name: "_amount1",
        type: "uint256",
      },
      {
        internalType: "bytes",
        name: "_data",
        type: "bytes",
      },
    ],
    name: "waultSwapCall",
    outputs: [],
    stateMutability: "nonpayable",
    type: "function",
  },
] as const;

const _bytecode =
  "0x6080806040523461002857600080546001600160a01b03191633179055610cda908161002e8239f35b600080fdfe60406080815260048036101561001457600080fd5b600090813560e01c92836253ae3e1461045757836310d1e85c146100a75783631c8f37b3146100a75783633fc01685146100a757836346337f3a146100a7578363485f3994146100a75783635b3bc4fe146100a757836384800812146100a75783638da5cb5b1461042b578363b2ff9f26146100a7578363b5a7a843146100ac5750505063ec78ce50146100a757600080fd5b6104fc565b346104275760e0366003190112610427576001600160a01b039160243583811690818103610423576100dc6104b7565b6100e46104d2565b9160a4359187831683036102d25760c43590888216820361041f57863543116103f657908161011985878d9560443588610b12565b9312156103cd57885163e6a4390560e01b81526001600160a01b0394851689820190815291909416602080830191909152939184918391908290036040019082908d165afa9081156103c3579089918b916103a6575b501694851561037d578751630dfe168160e01b815298838a89818a5afa998a15610373578b9a610354575b50885163d21220a760e01b815299848b8a818b5afa9a8b1561034a578c9b610319575b5081168015158061030e575b156102e55782036102de5782995b16036102d657925b86516001600160a01b0391821683820190815291909316602082015282906040010392610214601f19948581018552846109f7565b843b156102d25796929091889492875198899563022c0d9f60e01b875288870152602486015230604486015260806064860152815191826084870152865b8381106102b85750505060a4848093601f848985819786010152011681010301925af180156102ae57610283578380f35b67ffffffffffffffff831161029b5750528180808380f35b634e487b7160e01b845260419052602483fd5b82513d86823e3d90fd5b8181018301518b820160a401528b97508a96508201610252565b8880fd5b5087926101df565b8a996101d7565b895162461bcd60e51b8152808a01869052600360248201526265313160e81b6044820152606490fd5b50818b1615156101c9565b82919b5061033c90863d8811610343575b61033481836109f7565b810190610c6d565b9a906101bd565b503d61032a565b8a513d8e823e3d90fd5b61036c919a50843d86116103435761033481836109f7565b988b61019a565b89513d8d823e3d90fd5b875162461bcd60e51b8152808801849052600360248201526206531360ec1b6044820152606490fd5b6103bd9150843d86116103435761033481836109f7565b8b61016f565b88513d8c823e3d90fd5b885162461bcd60e51b81526020818a0152600360248201526265303160e81b6044820152606490fd5b875162461bcd60e51b8152602081890152600360248201526206530360ec1b6044820152606490fd5b8980fd5b8580fd5b8280fd5b905034610453578160031936011261045357905490516001600160a01b039091168152602090f35b5080fd5b90346104275760a036600319011261042757356001600160a01b0380821682036104b35760443590811681036104b357906104a7916104946104b7565b9061049d6104d2565b9260243590610b12565b82519182526020820152f35b8380fd5b606435906001600160a01b03821682036104cd57565b600080fd5b608435906001600160a01b03821682036104cd57565b35906001600160a01b03821682036104cd57565b346104cd5760803660031901126104cd576004356001600160a01b038116036104cd5760243560643567ffffffffffffffff8082116104cd57366023830112156104cd5781600401359081116104cd578101903660248301116104cd57826109be57604435915b604051630dfe168160e01b815291602083600481335afa9283156108635760009361099d575b5060405163d21220a760e01b815291602083600481335afa9283156108635760009361097c575b506040516105bd816109c5565b6002815260403660208301376040838151936105d8856109c5565b60028552823660208701378961097657865b6105f385610a19565b6001600160a01b039091169081905261060b86610a3f565b528961097057875b61061c85610a3f565b6001600160a01b039091169081905261063486610a19565b5203126104cd57610653604461064c602486016104e8565b94016104e8565b6001600160a01b0390811693908116151580610967575b1561093c57600091886109315760206106b0875b60405163095ea7b360e01b81526001600160a01b0389166004820152602481018c905295869283919082906044820190565b03926001600160a01b03165af1918215610863576106fa93600093610912575b5060405180809581946307c0329d60e21b83528c6004840152604060248401526044830190610ac8565b03916001600160a01b03165afa80156108635761071f916000916108f7575b50610a3f565b5194603c4201928342116108e1576000928361076593604051968795869485936338ed173960e01b855260048501528c602485015260a0604485015260a4840190610ac8565b90306064840152608483015203925af180156108635761078d916000916108be575b50610a19565b5193838511156108935761088c57505b60405163a9059cbb60e01b80825233600483015260248201849052909390916001600160a01b0316906020856044816000865af1948515610863576107fc6020956000926108299861086f575b5082546001600160a01b031693610b05565b6040519485526001600160a01b039092166004850152602484019190915291938492839182906044820190565b03925af180156108635761083957005b61085a9060203d60201161085c575b61085281836109f7565b810190610c8c565b005b503d610848565b6040513d6000823e3d90fd5b61088590883d8a1161085c5761085281836109f7565b50386107ea565b905061079d565b60405162461bcd60e51b815260206004820152600360248201526265313360e81b6044820152606490fd5b6108db91503d806000833e6108d381836109f7565b810190610a4c565b38610787565b634e487b7160e01b600052601160045260246000fd5b61090c91503d806000833e6108d381836109f7565b38610719565b61092a9060203d60201161085c5761085281836109f7565b50386106d0565b60206106b08861067e565b60405162461bcd60e51b815260206004820152600360248201526232989960e91b6044820152606490fd5b5083151561066a565b86610613565b876105ea565b61099691935060203d6020116103435761033481836109f7565b91386105b0565b6109b791935060203d6020116103435761033481836109f7565b9138610589565b8291610563565b6060810190811067ffffffffffffffff8211176109e157604052565b634e487b7160e01b600052604160045260246000fd5b90601f8019910116810190811067ffffffffffffffff8211176109e157604052565b805160011015610a295760400190565b634e487b7160e01b600052603260045260246000fd5b805115610a295760200190565b9060209081838203126104cd57825167ffffffffffffffff938482116104cd570181601f820112156104cd5780519384116109e1578360051b9060405194610a96858401876109f7565b855283808601928201019283116104cd578301905b828210610ab9575050505090565b81518152908301908301610aab565b90815180825260208080930193019160005b828110610ae8575050505090565b83516001600160a01b031685529381019392810192600101610ada565b919082039182116108e157565b610bb391939295946040938451610b28816109c5565b6002815285366020830137855193610b3f856109c5565b6002855286366020870137610b5385610a19565b6001600160a01b039a8b1690819052610b6b83610a3f565b5289610b7686610a3f565b9116809152610b8482610a19565b528551908163d06ca61f60e01b93848252896004830152886024830152818c8160009a8b966044830190610ac8565b0392165afa908115610c635791610bd986959392869593610bfb9891610c4f5750610a19565b5199875180978195829483528d60048401528a60248401526044830190610ac8565b0392165afa928315610c45575091610c209183610c26959492610c2a575b5050610a19565b51610b05565b9190565b610c3e92503d8091833e6108d381836109f7565b3880610c19565b51903d90823e3d90fd5b6108db91503d8088833e6108d381836109f7565b86513d87823e3d90fd5b908160209103126104cd57516001600160a01b03811681036104cd5790565b908160209103126104cd575180151581036104cd579056fea2646970667358221220e39db33aa480eb665dbf764c88a0976446822ba0f2d2ab8927859a89e5d7e23d64736f6c63430008180033";

type FlashswapConstructorParams =
  | [signer?: Signer]
  | ConstructorParameters<typeof ContractFactory>;

const isSuperArgs = (
  xs: FlashswapConstructorParams
): xs is ConstructorParameters<typeof ContractFactory> => xs.length > 1;

export class Flashswap__factory extends ContractFactory {
  constructor(...args: FlashswapConstructorParams) {
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
      Flashswap & {
        deploymentTransaction(): ContractTransactionResponse;
      }
    >;
  }
  override connect(runner: ContractRunner | null): Flashswap__factory {
    return super.connect(runner) as Flashswap__factory;
  }

  static readonly bytecode = _bytecode;
  static readonly abi = _abi;
  static createInterface(): FlashswapInterface {
    return new Interface(_abi) as FlashswapInterface;
  }
  static connect(address: string, runner?: ContractRunner | null): Flashswap {
    return new Contract(address, _abi, runner) as unknown as Flashswap;
  }
}
