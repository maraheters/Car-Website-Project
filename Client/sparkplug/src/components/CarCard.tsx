import styles from "../styles/CarList.module.scss";
import {Car} from "../api/api.ts";
import { formatPrice, formatMileage } from "../utils/utils.ts";

type CarCardProps = {
    car: Car; 
};

function CarCard({car}: CarCardProps) {
    const {year, images, manufacturer, model, price, mileage} = car;
    
    const coverImage: string = (images.length == 0) 
        ? "../../public/car-svgrepo-com.svg"
        : images[0];
    
    return (
        <div className={styles.card}>
            <figure><img src={coverImage} alt=""/></figure>
            <div className={styles.descriptionContainer}>
                <h2 className={styles.heading}>{year} {manufacturer} {model}</h2>
                <p>{formatPrice(price)}</p>
                <p>{formatMileage(mileage)} км</p>
            </div>
        </div>
    );
}

export default CarCard;