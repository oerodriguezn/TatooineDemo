using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Utils
{
    public class WCFproxy<T>
    {
        public static void Use(Action<T> action)
        {
            ChannelFactory<T> factory = new ChannelFactory<T>("*");
            T client = factory.CreateChannel();
            bool success = false;
            try
            {
                action(client);
                ((IClientChannel)client).Close();
                factory.Close();
                success = true;
            }
            catch (CommunicationException e)
            {
                LogUtil.Log("CommunicationException", e);
                throw;
            }
            catch (TimeoutException e)
            {
                LogUtil.Log("TimeoutException", e);
                throw;
            }
            catch (Exception e)
            {
                LogUtil.Log("Exception", e);
                throw;
            }
            finally
            {
                if(!success)
                {
                    ((IClientChannel)client).Abort();
                    factory.Abort();
                }
            }
        }
    }
}
