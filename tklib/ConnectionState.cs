// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib
{
    /// <summary>
    /// The state of a connection.
    /// </summary>
    public enum ConnectionState
    {
        /// <summary>
        /// The Connection is working
        /// </summary>
        IsOK,

        /// <summary>
        /// Connection doesn't work for some reason
        /// </summary>
        FailureUnspecified,

        /// <summary>
        /// At the given Address no Server was found
        /// </summary>
        FailureServerNotFound,

        /// <summary>
        /// The login failed, probably due wrong Username/Password
        /// </summary>
        FailureLogin,
    }
}
