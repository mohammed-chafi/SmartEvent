import { useEffect, useState } from "react";
import { useParams, Link } from "react-router-dom";
import { Event } from "../../Interfaces/Event";
import axios from "axios";
import { Subscriber } from "../../Interfaces/Subscriber";

export default function EventSubscribers() {
  const { eventId } = useParams();
  const [event, setEvent] = useState<Event>(Object);
  const [subscribers, setSubscribers] = useState<Subscriber[]>([]);

  useEffect(() => {
    axios
      .get("http://localhost:5040/api/event/" + eventId)
      .then((response) => {
        setEvent(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
    const token = localStorage.getItem("orgToken");
    axios
      .get("http://localhost:5040/api/Participant/allByEventId/" + eventId, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
      .then((response) => {
        setSubscribers(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, [eventId]);

  return (
    <div className="bg-white rounded-2xl shadow-sm p-8 mb-10">
      <div className="flex flex-col md:flex-row justify-between items-start md:items-center mb-8">
        <div>
          <h1 className="text-2xl font-bold text-gray-900 mb-2">
            Event Subscribers
          </h1>
          <p className="text-gray-600">
            {event.title} - {new Date(event.startDate).toLocaleDateString()}
          </p>
        </div>
        <Link
          to="/dashboard/events"
          className="inline-flex items-center px-4 py-2 border border-gray-300 rounded-xl text-sm font-medium text-gray-700 hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500"
        >
          Back to Events
        </Link>
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
                Registration Date
              </th>
            </tr>
          </thead>
          <tbody className="bg-white divide-y divide-gray-200">
            {subscribers.map((subscriber) => (
              <tr key={subscriber.firstName}>
                <td className="px-6 py-4 whitespace-nowrap">
                  <div className="text-sm font-medium text-gray-900">
                    {subscriber.firstName + " " + subscriber.lastName}
                  </div>
                </td>

                <td className="px-6 py-4 whitespace-nowrap">
                  <div className="text-sm text-gray-900">
                    {new Date(subscriber.dateRegistration).toLocaleDateString()}
                  </div>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
