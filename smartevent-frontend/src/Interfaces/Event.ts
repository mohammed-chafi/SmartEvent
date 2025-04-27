export interface Event {
  id: number;
  title: string;
  description: string;
  longDescription: string;
  date: string;
  time: string;
  location: string;
  imageUrl: string;
  category: string;
  price: number;
  capacity: number;
  registered: number;
  organizer: {
    name: string;
    email: string;
  };
}
