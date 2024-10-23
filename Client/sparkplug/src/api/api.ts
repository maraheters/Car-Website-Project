const local = false;
const API_URL = local ? "http://localhost:5140/api" : "http://172.20.36.81:5140/api"

export type Engine = {
    model: string;
    displacement: number;
    power: number;
    torque: number;
    fuelType: string;
    type: string;
    modifications: string;
}

export type Manufacturer = {
    name: string,
    country: string
}

export type Images = {
    urls: string[]
}

export type Transmission = {
    gearboxType: string,
    numberOfGears: number
}

export type Car = {
    id: string;
    model: string;
    price: number;
    mileage: number;
    year: number;
    manufacturer: Manufacturer;
    color: string;
    description: string;
    category: string;
    drivetrain: string
    images: Images;
    engine: Engine;
    transmission: Transmission
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