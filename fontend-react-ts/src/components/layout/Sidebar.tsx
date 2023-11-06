import { CiUser } from 'react-icons/ci';
import useAuth from '../../hooks/useAuth.hook';
import Button from '../general/Button';
import { useNavigate } from 'react-router-dom';
import { PATH_DASHOBARD } from '../../routers/paths';

const Sidebar = () => {
  const { user } = useAuth();
  const navigate = useNavigate();

  const handleClick = (url: string) => {
    window.scrollTo({ top: 0, left: 0, behavior: 'smooth' });
    navigate(url);
  };

  return (
    <div className='shrink-0 bg-[#754eb4] w-60 p-2 min-h-[calc(100vh-48px)] flex flex-col items-stretch gap-8'>
      <div className='self-center flex flex-col items-center'>
        <CiUser className='w-10 h-10 text-white' />
        <h4 className='text-white'>
          {user?.firstName} {user?.lastName}
        </h4>
      </div>

      <Button
        label='Users Management'
        onClick={() => handleClick(PATH_DASHOBARD.usersManagement)}
        type='button'
        variant='secondary'
      />
      <Button
        label='Send Message'
        onClick={() => handleClick(PATH_DASHOBARD.sendMessage)}
        type='button'
        variant='secondary'
      />
      <Button label='Inbox' onClick={() => handleClick(PATH_DASHOBARD.inbox)} type='button' variant='secondary' />
      <Button
        label='All Messages'
        onClick={() => handleClick(PATH_DASHOBARD.allMessages)}
        type='button'
        variant='secondary'
      />
      <Button
        label='All Logs'
        onClick={() => handleClick(PATH_DASHOBARD.systemLogs)}
        type='button'
        variant='secondary'
      />
      <Button label='My Logs' onClick={() => handleClick(PATH_DASHOBARD.myLogs)} type='button' variant='secondary' />
      <hr />
      <Button label='Owner Page' onClick={() => handleClick(PATH_DASHOBARD.owner)} type='button' variant='secondary' />
      <Button label='Admin Page' onClick={() => handleClick(PATH_DASHOBARD.admin)} type='button' variant='secondary' />
      <Button
        label='Manager Page'
        onClick={() => handleClick(PATH_DASHOBARD.manager)}
        type='button'
        variant='secondary'
      />
      <Button label='User Page' onClick={() => handleClick(PATH_DASHOBARD.user)} type='button' variant='secondary' />
    </div>
  );
};

export default Sidebar;