using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDPCOMAPILib;

namespace Thoth.Business
{
    public class ScreenSharing
    {
        RDPSession x = new RDPSession();
        public AxRDPCOMAPILib.AxRDPViewer axRDPViewer1;
        public string temp= null;

        public void Incoming(object Guest)
        {
            IRDPSRAPIAttendee MyGuest = (IRDPSRAPIAttendee)Guest;//???
            MyGuest.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE;
        }

        public void Start()
        {
            x.OnAttendeeConnected += Incoming;
            x.Open();
        }

        public void GetInvitation()
        {
            IRDPSRAPIInvitation Invitation = x.Invitations.CreateInvitation("Trial", "MyGroup", "", 10);
            temp = Invitation.ConnectionString;
        }

        public void Close()
        {
            x.Close();
            temp = null;
            x = null;
        }

        public void Connect()
        {
            x.OnAttendeeConnected += Incoming;
            x.Open();
            IRDPSRAPIInvitation Invitation = x.Invitations.CreateInvitation("Trial", "MyGroup", "", 10);
            temp = Invitation.ConnectionString;
            axRDPViewer1.Connect(temp, "User1", "");
        }

        public void Disconnect()
        {
            axRDPViewer1.Disconnect();
        }
    }
}
