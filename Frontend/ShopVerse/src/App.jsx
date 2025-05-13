
import './App.css'
import AdminLayouts from './Layouts/AdminLayouts.jsx'
import { Route, Routes } from 'react-router-dom'
import Dashboard from './Pages/AdminPage/Dashboard.jsx'
import LoginPage from './Pages/AuthPage/LoginPage.jsx'
import RegisterPage from './Pages/AuthPage/RegisterPage.jsx'
import Home from './pages/Home.jsx'
function App() {

  return (
    <Routes>
      <Route path="/admin" element={<AdminLayouts />}>
      <Route path="dashboard" element={<Dashboard /> }  />
      
      </Route>

      <Route path="/" element={<Home/>} />
      <Route path= "/Login" element={<LoginPage/>} />
      <Route path= "/Register" element={<RegisterPage/>} />
          
    </Routes>



  )
}

export default App
