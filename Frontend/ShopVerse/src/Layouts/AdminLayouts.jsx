
import { useNavigate } from 'react-router-dom';

const AdminLayout = ({ children }) => {
  const navigate = useNavigate();

  return (
    <div className="d-flex" style={{ minHeight: "100vh" }}>
      {/* Sidebar */}
      <div className="bg-dark text-white p-3" style={{ width: "20%" }}>
        <h4 className="text-white text-center mb-4 mt-2">Admin Panel</h4>
        <ul className="nav flex-column fs-5">
          <li className="nav-item">
            <a className="nav-link text-white" onClick={() => navigate("/admin/dashboard")} role="button">
              📊 Dashboard
            </a>
          </li>

          <li className="nav-item">
            <span className="nav-link text-white fw-bold">💻 Ürünler</span>
            <ul className="nav flex-column ms-3">
              <li className="nav-item"><a className="nav-link text-white" role='button'>Ürün Listele</a></li>
              <li className="nav-item"><a className="nav-link text-white">Ürün Ekle</a></li>
            </ul>
          </li>

          <li className="nav-item">
            <span className="nav-link text-white fw-bold">📦 Kategoriler</span>
            <ul className="nav flex-column ms-3">
              <li className="nav-item">
                <a className="nav-link text-white" role="button" onClick={() => navigate("/admin/categories")}>
                  Kategori Listele
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link text-white" role="button" onClick={() => navigate("/admin/categories/create")}>
                  Kategori Ekle
                </a>
              </li>
            </ul>
          </li>

          <li className="nav-item">
            <span className="nav-link text-white fw-bold">👤 Kullanıcılar</span>
            <ul className="nav flex-column ms-3">
              <li className="nav-item"><a className="nav-link text-white">Kullanıcı Listele</a></li>
              <li className="nav-item"><a className="nav-link text-white">Kullanıcı Ekle</a></li>
            </ul>
          </li>

          <li className="nav-item">
            <span className="nav-link text-white fw-bold">🛍️ Siparişler</span>
            <ul className="nav flex-column ms-3">
              <li className="nav-item"><a className="nav-link text-white">Sipraişleri Listele</a></li>
              
            </ul>
          </li>
        </ul>
      </div>

      {/* Main Content */}
      <div className="flex-grow-1 d-flex flex-column">
        <header className="bg-primary text-white py-3 px-4 fs-3">
          YTB Mern Stack App
        </header>
        <main className="flex-grow-1 p-4 bg-light">
          {children}
        </main>
        <footer className="bg-dark text-white text-center py-3">
          Footer
        </footer>
      </div>
    </div>
  );
};

export default AdminLayout;
