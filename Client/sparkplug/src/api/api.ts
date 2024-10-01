const API_URL = "http://localhost:5140/api"

export type Car = {
    id: string,
    model: string,
    price: number,
    mileage: number,
    year: number,
    manufacturer: string,
    category: string,
    images: string[],
}

const fetchCars = async (): Promise<Car[]> => {
    const response = await fetch(`${API_URL}/cars`);
    if (!response.ok) {
        throw new Error(`HTTP error: ${response.statusText}`);
    }
    const data = await response.json();
    return data;
}

export {fetchCars};