﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebRTCme.Connection
{
    public class PeerResponse
    {
        public PeerResponseType Type { get; init; }

        public Guid Id;

        public string Name { get; init; }

        public IMediaStream MediaStream { get; init; }

        public IRTCDataChannel DataChannel { get; init; }

        public MediaContext MediaContext { get; init; }

        public string ErrorMessage { get; init; }

    }
}
