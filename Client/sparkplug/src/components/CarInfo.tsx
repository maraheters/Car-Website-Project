// CarInfo.tsx
import { Car } from "../api/api";
import ImageGallery from "./ImageGallery.tsx";
import styles from "../styles/CarInfo.module.scss"
import { formatDisplacement, formatMileageKm, formatPrice } from "../utils/utils.ts";

type Props = {
    car: Car;
};

const CarInfo = ({ car }: Props) => {
    return (
        <div className={styles.carInfo}>
            <div className={styles.galleryAndQuickInfo}>
                <ImageGallery imageUrls={car.images} />
                <div>
                    <div className={styles.headings}>
                        <h1>{car.year} {car.manufacturer} {car.model}</h1>
                        <h2>{formatPrice(car.price)}</h2>
                        <h2>{formatMileageKm(car.mileage)}</h2>
                    </div>
                    {car.color && <h3>{car.color}</h3>}
                    {car.category && <h3>{car.category}</h3>}
                    {car.engine && car.engine.displacement != null && <h3>{formatDisplacement(car.engine.displacement)} {car.engine.type}</h3>}
                    {car.engine && car.engine.fuelType && <h3>{car.engine.fuelType}</h3>}
                </div>
            </div>   
        </div>
    );
}

export default CarInfo;