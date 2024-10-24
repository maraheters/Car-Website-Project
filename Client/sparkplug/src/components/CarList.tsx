import { useEffect, useState } from 'react';
import CarCard from './CarCard';
import { fetchCars, Car } from '../api/carApi';
import styles from '../styles/CarList.module.scss';

function CarList() {
    const [cars, setCars] = useState<Car[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const getCars = async () => {
            try {
                const data = await fetchCars();
                setCars(data);
            } catch (error: any) {
                console.error("Error fetching cars:", error.message); 
                setError(error.message); 
            } finally {
                setLoading(false);
            }
        };

        getCars();
    }, []);

    const carList = cars.map(car => (
        <li>
            <CarCard
                car={car}
            />
        </li>
    ));

    if (loading)
        return <div>Loading...</div>;
    
    if (error)
        return <div>Error: {error}</div>; 
    

    return (
        <ul className={`container ${styles.list}`}>{carList}</ul>
    );
}

export default CarList;