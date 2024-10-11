const API_URL = "http://localhost:5140/api"

export type Engine = {
    model: string;
    displacement: number;
    power: number;
    torque: number;
    fuelType: string;
    type: string;
    modifications: string;
}

export type Car = {
    id: string;
    model: string;
    price: number;
    mileage: number;
    year: number;
    manufacturer: string;
    color: string;
    description: string;
    category: string;
    images: string[];
    engine: Engine;
}

const fetchCars = async (): Promise<Car[]> => {
    const response = await fetch(`${API_URL}/cars`);
    if (!response.ok) {
        throw new Error(`HTTP error: ${response.statusText}`);
    }
    const data = await response.json();
    return data;
}

const fetchCarById = async (id: string): Promise<Car> => {
    const response = await fetch(`${API_URL}/cars/${id}`);
    if (!response.ok) {
        throw new Error(`HTTP error: ${response.statusText}`);
    }
    const data = await response.json();
    return data;
}

export {fetchCars, fetchCarById};