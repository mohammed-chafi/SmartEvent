import { useState } from "react";
import { useParams, Link } from "react-router-dom";

interface Event {
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
  requirements: string[];
  tags: string[];
}

export default function EventDetails() {
  const { eventId } = useParams();

  const event: Event = {
    id: 1,
    title: "Tech Conference 2024",
    description:
      "Annual technology conference featuring the latest innovations",
    longDescription: `Join us for the most anticipated tech conference of the year! This event brings together industry leaders, innovators, and technology enthusiasts for three days of learning, networking, and inspiration.

    What to expect:
    - Keynote speeches from industry leaders
    - Hands-on workshops
    - Networking opportunities
    - Latest technology showcases
    - Career development sessions
    
    Whether you're a developer, designer, product manager, or tech enthusiast, there's something for everyone at Tech Conference 2024.`,
    date: "2024-06-15",
    time: "09:00 AM",
    location: "Convention Center, New York",
    imageUrl:
      "https://images.unsplash.com/photo-1505373877841-8d25f7d46678?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1000&q=80",
    category: "conference",
    price: 299.99,
    capacity: 500,
    registered: 342,
    organizer: {
      name: "Tech Events Inc.",
      email: "contact@techevents.com",
    },
    requirements: [
      "Laptop (for workshops)",
      "Valid ID",
      "Registration confirmation",
    ],
    tags: ["Technology", "Conference", "Networking", "Workshops"],
  };

  const handleRegister = () => {};

  return (
    <div className="min-h-screen bg-gray-50 py-12 mt-12">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        {/* Back Button */}
        <Link
          to="/events"
          className="inline-flex items-center text-blue-600 hover:text-blue-800 mb-6"
        >
          <svg
            className="w-5 h-5 mr-2"
            fill="none"
            stroke="currentColor"
            viewBox="0 0 24 24"
          >
            <path
              strokeLinecap="round"
              strokeLinejoin="round"
              strokeWidth={2}
              d="M10 19l-7-7m0 0l7-7m-7 7h18"
            />
          </svg>
          Back to Events
        </Link>

        <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
          {/* Main Content */}
          <div className="lg:col-span-2">
            {/* Event Image */}
            <div className="relative rounded-xl overflow-hidden mb-6">
              <img
                src={event.imageUrl}
                alt={event.title}
                className="w-full h-96 object-cover"
              />
              <div className="absolute top-4 right-4">
                <span className="bg-blue-600 text-white px-3 py-1 rounded-full text-sm font-medium">
                  {event.category}
                </span>
              </div>
            </div>

            {/* Event Title and Basic Info */}
            <div className="bg-white rounded-xl shadow-sm p-6 mb-6">
              <h1 className="text-3xl font-bold text-gray-900 mb-4">
                {event.title}
              </h1>
              <div className="flex flex-wrap gap-4 text-gray-600 mb-6">
                <div className="flex items-center">
                  <svg
                    className="w-5 h-5 mr-2"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                  >
                    <path
                      strokeLinecap="round"
                      strokeLinejoin="round"
                      strokeWidth={2}
                      d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z"
                    />
                  </svg>
                  {new Date(event.date).toLocaleDateString("en-US", {
                    weekday: "long",
                    year: "numeric",
                    month: "long",
                    day: "numeric",
                  })}
                </div>
                <div className="flex items-center">
                  <svg
                    className="w-5 h-5 mr-2"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                  >
                    <path
                      strokeLinecap="round"
                      strokeLinejoin="round"
                      strokeWidth={2}
                      d="M12 8v4l3 3m6-3a9 9 0 11-18 0 9 9 0 0118 0z"
                    />
                  </svg>
                  {event.time}
                </div>
                <div className="flex items-center">
                  <svg
                    className="w-5 h-5 mr-2"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                  >
                    <path
                      strokeLinecap="round"
                      strokeLinejoin="round"
                      strokeWidth={2}
                      d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z"
                    />
                    <path
                      strokeLinecap="round"
                      strokeLinejoin="round"
                      strokeWidth={2}
                      d="M15 11a3 3 0 11-6 0 3 3 0 016 0z"
                    />
                  </svg>
                  {event.location}
                </div>
              </div>

              {/* Description */}
              <div className="prose max-w-none">
                <h2 className="text-xl font-semibold text-gray-900 mb-4">
                  About this event
                </h2>
                <p className="text-gray-600 whitespace-pre-line">
                  {event.longDescription}
                </p>
              </div>
            </div>
          </div>

          {/* Registration Sidebar */}
          <div className="lg:col-span-1">
            <div className="bg-white rounded-xl shadow-sm p-6 sticky top-6">
              <h2 className="text-xl font-semibold text-gray-900 mb-4">
                Registration
              </h2>
              <div className="space-y-4">
                <div className="flex justify-between items-center">
                  <span className="text-gray-600">Price per ticket</span>
                  <span className="font-semibold">
                    ${event.price.toFixed(2)}
                  </span>
                </div>
                <div className="flex justify-between items-center">
                  <span className="text-gray-600">Available spots</span>
                  <span className="font-semibold">
                    {event.capacity - event.registered} of {event.capacity}
                  </span>
                </div>

                <div className="pt-4 border-t border-gray-200">
                  <button
                    onClick={handleRegister}
                    className="w-full bg-blue-600 text-white py-3 px-4 rounded-lg hover:bg-blue-700 transition-colors"
                  >
                    Register Now
                  </button>
                </div>
              </div>
            </div>

            {/* Organizer Info */}
            <div className="bg-white rounded-xl shadow-sm p-6 mt-6">
              <h2 className="text-xl font-semibold text-gray-900 mb-4">
                Organizer
              </h2>
              <div className="space-y-2">
                <p className="text-gray-600">{event.organizer.name}</p>
                <p className="text-gray-600">{event.organizer.email}</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
