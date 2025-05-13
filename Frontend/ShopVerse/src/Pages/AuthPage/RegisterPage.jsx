import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

function RegisterPage() {
  const [userName, setUserName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [role, setRole] = useState('');
  const navigate = useNavigate();

 const handleRegister = async (e) => {
  e.preventDefault();

  try {
    const res = await fetch('http://localhost:5256/api/auth/register', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ userName, email, password, role }),
    });

    if (!res.ok) throw new Error('Kayıt başarısız');

    const data = await res.text(); 
    alert(data);
    navigate('/login'); 
  } catch (error) {
    alert('Hatalı kayıt: ' + error.message);
  }
};


  return (
    <div className="container" style={{ maxWidth: '400px', marginTop: '100px' }}>
      <div className="card shadow-lg p-4">
        <h3 className="text-center mb-4">Kayıt Ol</h3>
        <form onSubmit={handleRegister}>
          <div className="mb-3">
            <label htmlFor="userName" className="form-label">Kullanıcı Adı</label>
            <input
              type="text"
              id="userName"
              className="form-control"
              value={userName}
              onChange={(e) => setUserName(e.target.value)}
              required
            />
          </div>
          <div className="mb-3">
            <label htmlFor="email" className="form-label">Email</label>
            <input
              type="email"
              id="email"
              className="form-control"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              required
            />
          </div>
          <div className="mb-3">
            <label htmlFor="password" className="form-label">Şifre</label>
            <input
              type="password"
              id="password"
              className="form-control"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />
          </div>
          <div className="mb-3">
            <label htmlFor="role" className="form-label">Rol</label>
            <input
              type="text"
              id="role"
              className="form-control"
              value={role}
              onChange={(e) => setRole(e.target.value)}
              required
            />
          </div>
          <div className="d-grid gap-2">
            <button type="submit" className="btn btn-primary">Kayıt Ol</button>
          </div>
        </form>
      </div>
    </div>
  );
}

export default RegisterPage;
