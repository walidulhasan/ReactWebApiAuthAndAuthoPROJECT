import { Toaster } from "react-hot-toast"
import GlobalRouter from "./routers"


const App = () => {
  return (
    <div>
      <GlobalRouter />
      <Toaster/>
    </div>
  )
}

export default App