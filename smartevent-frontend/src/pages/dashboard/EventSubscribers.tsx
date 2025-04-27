import { useState } from "react";
import { useParams, Link } from "react-router-dom";

interface Subscriber {
  id: number;
  name: string;
  email: string;
  ticketType: string;
  registrationDate: string;
  status: "confirmed" | "pending" | "cancelled";
}

export default function EventSubscribers() {
  const { eventId } = useParams();
  const [searchTerm, setSearchTerm] = useState("");

  // Sample data - replace with actual API call
  const event = {
    id: Number(eventId),
    title: "Tech Conference 2024",
    date: "2024-06-15",
  };

  const subscribers: Subscriber[] = [
    {
      id: 1,
      name: "John Doe",
      email: "john@example.com",
      ticketType: "VIP",
      registrationDate: "2024-03-01",
      status: "confirmed",
    },
    {
      id: 2,
      name: "Jane Smith",
      email: "jane@example.com",
      ticketType: "Standard",
      registrationDate: "2024-03-02",
      status: "confirmed",
    },
    {
      id: 3,
      name: "Bob Johnson",
      email: "bob@example.com",
      ticketType: "Standard",
      registrationDate: "2024-03-03",
      status: "pending",
    },
    {
      id: 4,
      name: "Alice Brown",
      email: "alice@example.com",
      ticketType: "VIP",
      registrationDate: "2024-03-04",
      status: "cancelled",
    },
  ];

  const filteredSubscribers = subscribers.filter(
    (subscriber) =>
      subscriber.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
      subscriber.email.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const getStatusColor = (status: string) => {
    switch (status) {
      case "confirmed":
        return "bg-green-100 text-green-800";
      case "pending":
        return "bg-yellow-100 text-yellow-800";
      case "cancelled":
        return "bg-red-100 text-red-800";
      default:
        return "bg-gray-100 text-gray-800";
    }
  };

  return (
    <div className="bg-white rounded-2xl shadow-sm p-8">
      <div className="flex flex-col md:flex-row justify-between items-start md:items-center mb-8">
        <div>
          <h1 className="text-2xl font-bold text-gray-900 mb-2">
            Event Subscribers
          </h1>
          <p className="text-gray-600">
            {event.title} - {new Date(event.date).toLocaleDateString()}
          </p>
        </div>
        <Link
          to="/dashboard/events"
          className="inline-flex items-center px-4 py-2 border border-gray-300 rounded-xl text-sm font-medium text-gray-700 hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500"
        >
          Back to Events
        </Link>
      </div>

      {/* Search Bar */}
      <div className="mb-6">
        <div className="relative">
          <div className="absolute inset-y-0 left-0 pl-3 flex items-center pointer-events-none">
            <svg
              className="h-5 w-5 text-gray-400"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth={2}
                d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"
              />
            </svg>
          </div>
          <input
            type="text"
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
            className="block w-full pl-10 pr-4 py-2 border border-gray-200 rounded-xl focus:ring-2 focus:ring-blue-500 focus:border-transparent"
            placeholder="Search subscribers..."
          />
        </div>
      </div>

      {/* Subscribers Table */}
      <div className="overflow-x-auto">
        <table className="min-w-full divide-y divide-gray-200">
          <thead className="bg-gray-50">
            <tr>
              <th
                scope="col"
                className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"
              >
                Name
              </th>
              <th
                scope="col"
                className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"
              >
                Email
              </th>
              <th
                scope="col"
                className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"
              >
                Ticket Type
              </th>
              <th
                scope="col"
                className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"
              >
                Registration Date
              </th>
              <th
                scope="col"
                className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"
              >
                Status
              </th>
            </tr>
          </thead>
          <tbody className="bg-white divide-y divide-gray-200">
            {filteredSubscribers.map((subscriber) => (
              <tr key={subscriber.id}>
                <td className="px-6 py-4 whitespace-nowrap">
                  <div className="text-sm font-medium text-gray-900">
                    {subscriber.name}
                  </div>
                </td>
                <td className="px-6 py-4 whitespace-nowrap">
                  <div className="text-sm text-gray-900">
                    {subscriber.email}
                  </div>
                </td>
                <td className="px-6 py-4 whitespace-nowrap">
                  <div className="text-sm text-gray-900">
                    {subscriber.ticketType}
                  </div>
                </td>
                <td className="px-6 py-4 whitespace-nowrap">
                  <div className="text-sm text-gray-900">
                    {new Date(subscriber.registrationDate).toLocaleDateString()}
                  </div>
                </td>
                <td className="px-6 py-4 whitespace-nowrap">
                  <span
                    className={`px-2 inline-flex text-xs leading-5 font-semibold rounded-full ${getStatusColor(
                      subscriber.status
                    )}`}
                  >
                    {subscriber.status.charAt(0).toUpperCase() +
                      subscriber.status.slice(1)}
                  </span>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      {/* No Results Message */}
      {filteredSubscribers.length === 0 && (
        <div className="text-center py-12">
          <p className="text-gray-500">
            No subscribers found matching your search.
          </p>
        </div>
      )}
    </div>
  );
}
