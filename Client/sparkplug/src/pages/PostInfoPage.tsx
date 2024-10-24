import { useParams } from "react-router-dom";
import CarInfo from "../components/CarInfo";
import { useEffect, useState } from "react";
import { fetchCarById, Car } from "../api/carApi";
import Header from "../components/Header";

function PostInfoPage() {
    const [car, setCar] = useState<Car | null>(null);
    const [error, setError] = useState<string | null>(null);
    const [loading, setLoading] = useState<boolean>(true);
    const { carId } = useParams<{ carId: string }>();

    if (!carId) {
        return <div>Car ID not found</div>;
    }

    useEffect(() => {
        const fetchCar = async () => {
            try {
                const data = await fetchCarById(carId);
                setCar(data);
            } catch (error: any) {
                setError(error.message);
            } finally {
                setLoading(false);
            }
        };

        fetchCar();
    }, [carId]);

    if (loading) return <div>Loading...</div>;
    if (error) return <div>{error}</div>;
    
    if (!car) return <div>No car information available</div>;

    return (
        <>
            <Header></Header>
            <CarInfo car={car} />
        </>
    );
}

export default PostInfoPage;