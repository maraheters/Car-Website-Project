import styles from '../styles/Header.module.css';
import { Link } from "react-router-dom";
function Header() {
    return (
        <header className={styles.header}>
            <div className={styles.logoAndNav}>
                <h1 className={styles.logo}>#bomb gay poit</h1>
                <div className={styles.navContainer}>
                    <div className={styles.navElementContainer}>
                        <Link to="/">Главная</Link>
                    </div>
                    <div className={styles.navElementContainer}>
                        <Link to="/movies">Фильмы</Link>
                    </div>
                </div>
            </div>
            <div className={styles.login_button_container}>
                <Link to="/login">
                    <button>Войти</button>
                </Link>
            </div>
        </header>
    )
}

export default Header;