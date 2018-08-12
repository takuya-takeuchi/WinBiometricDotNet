﻿using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class BiometricIdentity
    {

        #region Constructors

        internal BiometricIdentity(SafeNativeMethods.WINBIO_IDENTITY identity)
        {
            this.Type = (IdentityTypes)identity.Type;
            var value = identity.Value;

            switch (this.Type)
            {
                case IdentityTypes.Null:
                    break;
                case IdentityTypes.WildCard:
                    break;
                case IdentityTypes.Guid:
                    unsafe
                    {
                        var templateGuid = value.TemplateGuid;
                        var a = (int)templateGuid.Data1;
                        var b = (short)templateGuid.Data2;
                        var c = (short)templateGuid.Data3;
                        var d = new byte[8];
                        Marshal.Copy((IntPtr)templateGuid.Data4, d, 0, d.Length);
                        this.TemplateGuid = new Guid(a, b, c, d);
                    }
                    break;
                case IdentityTypes.Sid:
                    unsafe
                    {
                        var accountSid = value.AccountSid;
                        var binaryForm = new byte[accountSid.Size];
                        Marshal.Copy((IntPtr)accountSid.Data, binaryForm, 0, binaryForm.Length);
                        this.Sid = new SecurityIdentifier(binaryForm, 0);
                    }
                    break;
            }

            this.Source = identity;
        }

        #endregion

        #region Properties

        public IdentityTypes Type
        {
            get;
        }

        public SecurityIdentifier Sid
        {
            get;
        }

        internal SafeNativeMethods.WINBIO_IDENTITY Source
        {
            get;
        }

        public Guid TemplateGuid
        {
            get;
        }

        #endregion

    }

}