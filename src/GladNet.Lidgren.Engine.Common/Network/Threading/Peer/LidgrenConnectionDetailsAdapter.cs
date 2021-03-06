﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using Lidgren.Network;
using GladNet.Engine.Common;

namespace GladNet.Lidgren.Engine.Common
{
	//Basically the same as the PhotonServer details adapter.
	/// <summary>
	/// Lidgren details adapter for the <see cref="IConnectionDetails"/> interface.
	/// </summary>
	public class LidgrenConnectionDetailsAdapter : IConnectionDetails
	{
		/// <summary>
		/// IPAddress of the remote peer.
		/// </summary>
		public IPAddress RemoteIP { get; }

		/// <summary>
		/// Remote port of the peer.
		/// </summary>
		public int RemotePort { get; }

		/// <summary>
		/// Local port the peer is connecting on.
		/// </summary>
		public int LocalPort { get; }

		/// <summary>
		/// AUID of the peer. (Application-wide unique)
		/// </summary>
		public int ConnectionID { get; }

		/// <summary>
		/// Creates a new adapter for the <see cref="IConnectionDetails"/> interface.
		/// </summary>
		/// <param name="remoteIP">Remote IP address of the connection.</param>
		/// <param name="remotePort">Remote port of the connection.</param>
		/// <param name="localPort">Local port of the connection.</param>
		/// <param name="connectionID">Unique (port-wise) ID of the connection.</param>
		public LidgrenConnectionDetailsAdapter(string remoteIP, int remotePort, int localPort, int uniqueIdentifier)
		{
			if (string.IsNullOrEmpty(remoteIP)) throw new ArgumentException("Value cannot be null or empty.", nameof(remoteIP));
			if (remotePort <= 0) throw new ArgumentOutOfRangeException(nameof(remotePort));
			if (localPort <= 0) throw new ArgumentOutOfRangeException(nameof(localPort));

			RemoteIP = IPAddress.Parse(remoteIP);
			RemotePort = remotePort;
			LocalPort = localPort;
			ConnectionID = uniqueIdentifier;
		}
	}
}
