import { useState } from 'react';
import styles from '../styles/Header.module.scss';
import { Link } from "react-router-dom";

function Header() {
    const [isSidebarVisible, setIsSidebarVisible] = useState(false);

    const showSidebar = () => {
        setIsSidebarVisible(prevState => !prevState);
    };

    return (
        <header>
            <nav className={styles.header__nav}>
                <div className={`container`}>
                    <ul className={styles.header__list}>
                        <li className={styles.header__logo}>sparkplug</li>
                        <li className={styles.hideOnMobile}><Link to="/">Главная</Link></li>
                        <li className={styles.hideOnMobile}><Link to="/news">Новости</Link></li>
                        <div className={styles.rightSide}>
                            <li className={styles.hideOnMobile}><Link to="/login">Войти</Link></li>
                            <li className={styles.menuButton} onClick={showSidebar} ><Link to="#"><svg xmlns="http://www.w3.org/2000/svg" height="24px" viewBox="0 -960 960 960" width="24px" fill="#e8eaed"><path d="M120-240v-80h720v80H120Zm0-200v-80h720v80H120Zm0-200v-80h720v80H120Z"/></svg></Link></li>
                        </div>
                        
                    </ul>
                </div>
                {isSidebarVisible && <div className={styles.header__sidebar}>
                    <ul>
                        <li onClick={showSidebar}><Link to="#"><svg xmlns="http://www.w3.org/2000/svg" height="24px" viewBox="0 -960 960 960" width="24px" fill="#e8eaed"><path d="m256-200-56-56 224-224-224-224 56-56 224 224 224-224 56 56-224 224 224 224-56 56-224-224-224 224Z"/></svg></Link></li>
                        <li><Link to="/login">Войти</Link></li>
                        <li><Link to="/">Главная</Link></li>
                        <li><Link to="/news">Новости</Link></li>
                    </ul>
                </div>}
            </nav>
        </header>
    );
}

export default Header;