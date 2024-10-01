import React, {useEffect, useState} from 'react';
import CarCard from './CarCard';
import {fetchCars} from '../api/api.js';
import {Link} from 'react-router-dom';
import {Car} from '../api/api'

function CarList() {
    const [cars, setCars] = useState<Car[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState(true);

    useEffect(() => {
        const getCars = async () => {
            try {
                const data = await fetchCars();
                setCars(data);
            } catch (error: any) {
                setError(error);
            } finally {
                setLoading(false);
            }
        }
        
        getCars();
    }, []);

    const carList = cars.map(car => {
        return (
            <Link to={`/car/${car.id}`} style={{textDecoration: "none"}}>
                <li key={car.id}>
                    <CarCard
                    year={car.year}
                    manufacturer={car.manufacturer}
                    model = {car.model}
                    price = {car.price}
                    mileage = {car.mileage}
                    images = {car.images}
                    />
                </li>
            </Link>
        );
    });
    
    return (
        <ul style={{marginTop: "200px"}}> {carList} </ul>
    )
}

export default CarList