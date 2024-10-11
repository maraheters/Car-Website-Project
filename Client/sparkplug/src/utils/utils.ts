function formatPrice(price: number): string {
    return `$${price.toLocaleString()}`;
}

function formatMileageKm(mileage: number): string {
    return `${mileage.toLocaleString()}km`;
}

function formatDisplacement(displacement: number): string {
    return `${displacement.toFixed(1)}L`;
}

export { formatPrice, formatMileageKm, formatDisplacement };