export interface Moon {
  moonId: number;
  planetId: number;
  name: string;
  description: string;
  image: string;
}
export interface Planet {
  planetId: number;
  name: string;
  description: string;
  image: string;
  moons: Moon[];
}