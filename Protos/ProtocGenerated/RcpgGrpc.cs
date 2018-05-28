// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: rcpg.proto
// </auto-generated>
#pragma warning disable 1591
#region Designer generated code

using System;
using System.Threading;
using System.Threading.Tasks;
using grpc = global::Grpc.Core;

namespace Rcpg {
  public static partial class PaymentGatewayGrpc
  {
    static readonly string __ServiceName = "rcpg.PaymentGatewayGrpc";

    static readonly grpc::Marshaller<global::Rcpg.InitiateCardlessRequest> __Marshaller_InitiateCardlessRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Rcpg.InitiateCardlessRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Rcpg.InitiateCardlessResponse> __Marshaller_InitiateCardlessResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Rcpg.InitiateCardlessResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Rcpg.PayStandardRequest> __Marshaller_PayStandardRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Rcpg.PayStandardRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Rcpg.PayResponse> __Marshaller_PayResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Rcpg.PayResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Rcpg.PayCardlessRequest> __Marshaller_PayCardlessRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Rcpg.PayCardlessRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Rcpg.CaptureRequest> __Marshaller_CaptureRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Rcpg.CaptureRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Rcpg.GetDetailsRequest> __Marshaller_GetDetailsRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Rcpg.GetDetailsRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Rcpg.GetDetailsResponse> __Marshaller_GetDetailsResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Rcpg.GetDetailsResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Rcpg.InitiateCardlessRequest, global::Rcpg.InitiateCardlessResponse> __Method_InitiateCardless = new grpc::Method<global::Rcpg.InitiateCardlessRequest, global::Rcpg.InitiateCardlessResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "InitiateCardless",
        __Marshaller_InitiateCardlessRequest,
        __Marshaller_InitiateCardlessResponse);

    static readonly grpc::Method<global::Rcpg.PayStandardRequest, global::Rcpg.PayResponse> __Method_PayStandard = new grpc::Method<global::Rcpg.PayStandardRequest, global::Rcpg.PayResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "PayStandard",
        __Marshaller_PayStandardRequest,
        __Marshaller_PayResponse);

    static readonly grpc::Method<global::Rcpg.PayCardlessRequest, global::Rcpg.PayResponse> __Method_PayCardless = new grpc::Method<global::Rcpg.PayCardlessRequest, global::Rcpg.PayResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "PayCardless",
        __Marshaller_PayCardlessRequest,
        __Marshaller_PayResponse);

    static readonly grpc::Method<global::Rcpg.CaptureRequest, global::Rcpg.PayResponse> __Method_Capture = new grpc::Method<global::Rcpg.CaptureRequest, global::Rcpg.PayResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Capture",
        __Marshaller_CaptureRequest,
        __Marshaller_PayResponse);

    static readonly grpc::Method<global::Rcpg.GetDetailsRequest, global::Rcpg.GetDetailsResponse> __Method_GetDetails = new grpc::Method<global::Rcpg.GetDetailsRequest, global::Rcpg.GetDetailsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetDetails",
        __Marshaller_GetDetailsRequest,
        __Marshaller_GetDetailsResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Rcpg.RcpgReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of PaymentGatewayGrpc</summary>
    public abstract partial class PaymentGatewayGrpcBase
    {
      /// <summary>
      /// Initiates either Authorize or Purchase action. Initiation can only be cardless.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Rcpg.InitiateCardlessResponse> InitiateCardless(global::Rcpg.InitiateCardlessRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Based on intent executes either Authorize or Purchase action for standard payment.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Rcpg.PayResponse> PayStandard(global::Rcpg.PayStandardRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Based on intent executes either Authorize or Purchase action for cardless payment.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Rcpg.PayResponse> PayCardless(global::Rcpg.PayCardlessRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Can capture both cardless and standard authorization.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Rcpg.PayResponse> Capture(global::Rcpg.CaptureRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Gets payment details by token or transaction. Only supported by PayPal Express Checkout.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Rcpg.GetDetailsResponse> GetDetails(global::Rcpg.GetDetailsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for PaymentGatewayGrpc</summary>
    public partial class PaymentGatewayGrpcClient : grpc::ClientBase<PaymentGatewayGrpcClient>
    {
      /// <summary>Creates a new client for PaymentGatewayGrpc</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public PaymentGatewayGrpcClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for PaymentGatewayGrpc that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public PaymentGatewayGrpcClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected PaymentGatewayGrpcClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected PaymentGatewayGrpcClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// Initiates either Authorize or Purchase action. Initiation can only be cardless.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Rcpg.InitiateCardlessResponse InitiateCardless(global::Rcpg.InitiateCardlessRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return InitiateCardless(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Initiates either Authorize or Purchase action. Initiation can only be cardless.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Rcpg.InitiateCardlessResponse InitiateCardless(global::Rcpg.InitiateCardlessRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_InitiateCardless, null, options, request);
      }
      /// <summary>
      /// Initiates either Authorize or Purchase action. Initiation can only be cardless.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Rcpg.InitiateCardlessResponse> InitiateCardlessAsync(global::Rcpg.InitiateCardlessRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return InitiateCardlessAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Initiates either Authorize or Purchase action. Initiation can only be cardless.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Rcpg.InitiateCardlessResponse> InitiateCardlessAsync(global::Rcpg.InitiateCardlessRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_InitiateCardless, null, options, request);
      }
      /// <summary>
      /// Based on intent executes either Authorize or Purchase action for standard payment.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Rcpg.PayResponse PayStandard(global::Rcpg.PayStandardRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return PayStandard(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Based on intent executes either Authorize or Purchase action for standard payment.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Rcpg.PayResponse PayStandard(global::Rcpg.PayStandardRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_PayStandard, null, options, request);
      }
      /// <summary>
      /// Based on intent executes either Authorize or Purchase action for standard payment.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Rcpg.PayResponse> PayStandardAsync(global::Rcpg.PayStandardRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return PayStandardAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Based on intent executes either Authorize or Purchase action for standard payment.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Rcpg.PayResponse> PayStandardAsync(global::Rcpg.PayStandardRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_PayStandard, null, options, request);
      }
      /// <summary>
      /// Based on intent executes either Authorize or Purchase action for cardless payment.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Rcpg.PayResponse PayCardless(global::Rcpg.PayCardlessRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return PayCardless(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Based on intent executes either Authorize or Purchase action for cardless payment.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Rcpg.PayResponse PayCardless(global::Rcpg.PayCardlessRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_PayCardless, null, options, request);
      }
      /// <summary>
      /// Based on intent executes either Authorize or Purchase action for cardless payment.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Rcpg.PayResponse> PayCardlessAsync(global::Rcpg.PayCardlessRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return PayCardlessAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Based on intent executes either Authorize or Purchase action for cardless payment.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Rcpg.PayResponse> PayCardlessAsync(global::Rcpg.PayCardlessRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_PayCardless, null, options, request);
      }
      /// <summary>
      /// Can capture both cardless and standard authorization.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Rcpg.PayResponse Capture(global::Rcpg.CaptureRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return Capture(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Can capture both cardless and standard authorization.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Rcpg.PayResponse Capture(global::Rcpg.CaptureRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Capture, null, options, request);
      }
      /// <summary>
      /// Can capture both cardless and standard authorization.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Rcpg.PayResponse> CaptureAsync(global::Rcpg.CaptureRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return CaptureAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Can capture both cardless and standard authorization.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Rcpg.PayResponse> CaptureAsync(global::Rcpg.CaptureRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Capture, null, options, request);
      }
      /// <summary>
      /// Gets payment details by token or transaction. Only supported by PayPal Express Checkout.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Rcpg.GetDetailsResponse GetDetails(global::Rcpg.GetDetailsRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return GetDetails(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Gets payment details by token or transaction. Only supported by PayPal Express Checkout.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Rcpg.GetDetailsResponse GetDetails(global::Rcpg.GetDetailsRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetDetails, null, options, request);
      }
      /// <summary>
      /// Gets payment details by token or transaction. Only supported by PayPal Express Checkout.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Rcpg.GetDetailsResponse> GetDetailsAsync(global::Rcpg.GetDetailsRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return GetDetailsAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Gets payment details by token or transaction. Only supported by PayPal Express Checkout.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Rcpg.GetDetailsResponse> GetDetailsAsync(global::Rcpg.GetDetailsRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetDetails, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override PaymentGatewayGrpcClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new PaymentGatewayGrpcClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(PaymentGatewayGrpcBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_InitiateCardless, serviceImpl.InitiateCardless)
          .AddMethod(__Method_PayStandard, serviceImpl.PayStandard)
          .AddMethod(__Method_PayCardless, serviceImpl.PayCardless)
          .AddMethod(__Method_Capture, serviceImpl.Capture)
          .AddMethod(__Method_GetDetails, serviceImpl.GetDetails).Build();
    }

  }
}
#endregion
