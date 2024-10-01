import styles from '../styles/Header.module.scss';
import { Link } from "react-router-dom";

function Header() {
    return (
        <header>
            <nav className={styles.navBar}>
                <h1 className={styles.logo}>sparkplug</h1>
                <div className={styles.navContainer}>
                    <Link to="/">Главная</Link>
                    <Link to="/news">Новости</Link>
                </div>
                <div className={styles.login_button_container}>
                    <Link to="/login">
                        <button>Войти</button>
                    </Link>
                </div>
            </nav>
        </header>
    );
}

export default Header;