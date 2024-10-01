import styles from "../styles/CarCard.module.scss";

interface CardProps {
    year: number;
    mileage: number;
    price: number;
    manufacturer: string;
    model: string;
    images: string[];
}

function CarCard({year, images, manufacturer, model, price, mileage}: CardProps) {
    let img: string;
    if (images.length == 0)
        img = "";
    else 
        img = images[0];
    
    
    return (
        <div className={styles.card}>
            <figure><img src={img} alt=""/></figure>
            <div className={styles.descriptionContainer}>
                <h2 className={styles.heading}>{year} {manufacturer} {model}</h2>
                <h4>Цена: {price}</h4>
                <h4>Пробег: {mileage}</h4>
            </div>
        </div>
    );
}

export default CarCard;