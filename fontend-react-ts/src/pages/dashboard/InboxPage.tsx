
import { useEffect, useState } from "react"
import { ImessageDto } from "../../types/message.types"
import axiosInstance from "../../utils/axioxInstance"
import { MY_MESSAGE_URL } from "../../utils/globalConfig"
import { toast } from "react-hot-toast"
import Spinner from "../../components/general/Spinner"
import { MdInput, MdOutput } from 'react-icons/md'
import useAuth from "../../hooks/useAuth.hook"
import moment from "moment"

const InboxPage = () => {
  const { user } = useAuth();
  const [message, setMessage] = useState<ImessageDto[]>([]);
  const [loading, setLoading] = useState<boolean>(false);

  const getMyMessages = async () => {
    try {
      setLoading(true);
      const response = await axiosInstance.get<ImessageDto[]>(MY_MESSAGE_URL);
      const { data } = response;
      setMessage(data);
      setLoading(false);
    } catch (error) {
      toast.error('An Error happend. Please Contract admins')
      setLoading(false);
    }
  }

  useEffect(() => {
    getMyMessages()
  }, [])
  if (loading) {
    return (
      <div className="w-full">
        <Spinner />
      </div>
    );
  }
  return (
    <div className='pageTemplate2'>
      <h1 className="text-2xl font-bold">Inbox</h1>
      <div className="pageTemplate3 items-stretch">
        <div className="grid grid-cols-8 p-2 border-2 border-gray-200 rounded-lg">
          <span>Date</span>
          <span>Type</span>
          <span className="col-span-4">Text</span>
          <span>Sender</span>
          <span>Receiver</span>
        </div>
        {
          message.map((item) => (
            <div key={item.id} className="grid grid-cols-8 p-2 border-2 border-gray-200 rounded-lg">
              <span>{moment(item.createAt).fromNow()}</span>
              <span>
                {item.senderUserName === user?.userName ? (
                  <MdOutput className="text-2xl text-purple-500" />
                ) : (
                  <MdInput className='text-2xl text-green-500' />
                )}
              </span>
              <span className="col-span-4">{item.text}</span>
              <span>{item.senderUserName}</span>
              <span>{item.receiverUserName}</span>
            </div>
          ))
        }
      </div>
    </div>
  )
}

export default InboxPage