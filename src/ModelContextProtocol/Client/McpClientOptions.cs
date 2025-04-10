using ModelContextProtocol.Protocol.Types;

namespace ModelContextProtocol.Client;

/// <summary>
/// Provides configuration options for creating <see cref="IMcpClient"/> instances.
/// </summary>
/// <remarks>
/// These options are typically passed to <see cref="McpClientFactory.CreateAsync"/> when creating a client.
/// They define client capabilities, protocol version, and other client-specific settings.
/// </remarks>
public class McpClientOptions
{
    /// <summary>
    /// Gets or sets information about this client implementation, including its name and version.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This information is sent to the server during initialization to identify the client.
    /// It's often displayed in server logs and can be used for debugging and compatibility checks.
    /// </para>
    /// <para>
    /// When not specified, information sourced from the current process will be used.
    /// </para>
    /// </remarks>
    public Implementation? ClientInfo { get; set; }

    /// <summary>
    /// Gets or sets the client capabilities to advertise to the server.
    /// </summary>
    public ClientCapabilities? Capabilities { get; set; }

    /// <summary>
    /// Gets or sets the protocol version to request from the server, using a date-based versioning scheme.
    /// </summary>
    /// <remarks>
    /// The protocol version is a key part of the initialization handshake. The client and server must 
    /// agree on a compatible protocol version to communicate successfully. If the server doesn't support
    /// the requested version, it will respond with a version mismatch error.
    /// </remarks>
    public string ProtocolVersion { get; set; } = "2024-11-05";

    /// <summary>
    /// Gets or sets a timeout for the client-server initialization handshake sequence.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This timeout determines how long the client will wait for the server to respond during
    /// the initialization protocol handshake. If the server doesn't respond within this timeframe,
    /// an exception will be thrown.
    /// </para>
    /// <para>
    /// Setting an appropriate timeout prevents the client from hanging indefinitely when
    /// connecting to unresponsive servers.
    /// </para>
    /// <para>The default value is 60 seconds.</para>
    /// </remarks>
    public TimeSpan InitializationTimeout { get; set; } = TimeSpan.FromSeconds(60);
}
