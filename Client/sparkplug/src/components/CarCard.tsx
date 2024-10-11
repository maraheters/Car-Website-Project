import styles from "../styles/CarList.module.scss";
import {Car} from "../api/api.ts";
import { formatPrice, formatMileageKm, formatDisplacement } from "../utils/utils.ts";
import { Link } from "react-router-dom";

type CarCardProps = {
    car: Car; 
};

function CarCard({car}: CarCardProps) {
    const {year, images, manufacturer, model, price, mileage} = car;
    
    const coverImage: string = (images.length == 0) 
        ? "../../public/car-svgrepo-com.svg"
        : images[0];
    
    return (
        <Link to={`/cars/${car.id}`} className={styles.link}>
            <div className={styles.card}>
                <figure><img src={coverImage} alt=""/></figure>
                <div className={styles.descriptionContainer}>
                    <h2 className={styles.heading}>{year} {manufacturer} {model}</h2>
                    {car.engine && <h3> {formatDisplacement(car.engine.displacement)} {car.engine.type}</h3>}
                    <p>{formatPrice(price)}</p>
                    <p>{formatMileageKm(mileage)}</p>
                </div>
            </div>
        </Link>
    );
}

export default CarCard;