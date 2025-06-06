import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Event } from "../../Interfaces/Event";
import axios from "axios";

export default function EventEdit() {
  const navigate = useNavigate();
  const { eventId } = useParams();
  const [formData, setFormData] = useState<Event>(Object);
  const [time, setTime] = useState<string>("");

  useEffect(() => {
    axios
      .get("http://localhost:5040/api/event/" + eventId)
      .then((response) => {
        setFormData(response.data);
        setTime(response.data.startDate.slice(11, 16));
      })
      .catch((error) => {
        console.log(error);
      });
  }, [eventId]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    const token = localStorage.getItem("orgToken");
    formData.startDate = formData.startDate.slice(0, 10) + "T" + time + ":00Z";
    console.log(formData);
    await axios.put("http://localhost:5040/api/event/" + eventId, formData, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
    console.log("Event updated:", formData);
    navigate("/dashboard/events");
  };

  const handleChange = (
    e: React.ChangeEvent<
      HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement
    >
  ) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
    if (name == "time") setTime(value);
  };

  return (
    <div className="bg-white rounded-2xl shadow-sm p-8 mb-32">
      <div className="max-w-3xl mx-auto">
        <div className="flex items-center justify-between mb-8">
          <div>
            <h1 className="text-2xl font-bold text-gray-900">Edit Event</h1>
            <p className="mt-1 text-sm text-gray-500">
              Update the event details below
            </p>
          </div>
          <button
            onClick={() => navigate("/dashboard/events")}
            className="inline-flex items-center px-4 py-2 text-sm font-medium text-gray-700 bg-white border border-gray-300 rounded-xl hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500"
          >
            <svg
              className="w-5 h-5 mr-2"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth={2}
                d="M10 19l-7-7m0 0l7-7m-7 7h18"
              />
            </svg>
            Back to Events
          </button>
        </div>

        <form onSubmit={handleSubmit} className="space-y-8">
          {/* Basic Information Section */}
          <div className="bg-gray-50 rounded-xl p-6">
            <h2 className="text-lg font-semibold text-gray-900 mb-4">
              Basic Information
            </h2>
            <div>
              <label
                htmlFor="title"
                className="block text-sm font-medium text-gray-700 mb-1"
              >
                Event Title
              </label>
              <input
                type="text"
                id="title"
                name="title"
                value={formData.title}
                onChange={handleChange}
                required
                className="block w-full px-4 py-3 text-gray-900 placeholder-gray-400 bg-white border border-gray-200 rounded-xl shadow-sm transition-all duration-200 focus:ring-2 focus:ring-blue-500 focus:border-transparent hover:border-gray-300"
                placeholder="Enter event title"
              />
            </div>

            <div className="mt-6">
              <label
                htmlFor="description"
                className="block text-sm font-medium text-gray-700 mb-1"
              >
                Description
              </label>
              <textarea
                id="description"
                name="description"
                value={formData.description}
                onChange={handleChange}
                required
                rows={4}
                className="block w-full px-4 py-3 text-gray-900 placeholder-gray-400 bg-white border border-gray-200 rounded-xl shadow-sm transition-all duration-200 focus:ring-2 focus:ring-blue-500 focus:border-transparent hover:border-gray-300 resize-none"
                placeholder="Enter event description"
              />
            </div>
          </div>

          {/* Date and Location Section */}
          <div className="bg-gray-50 rounded-xl p-6">
            <h2 className="text-lg font-semibold text-gray-900 mb-4">
              Date and Location
            </h2>
            <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
              <div>
                <label
                  htmlFor="date"
                  className="block text-sm font-medium text-gray-700 mb-1"
                >
                  Date
                </label>
                <input
                  type="date"
                  id="startDate"
                  name="startDate"
                  value={
                    formData.startDate ? formData.startDate.slice(0, 10) : ""
                  }
                  onChange={handleChange}
                  required
                  className="block w-full px-4 py-3 text-gray-900 placeholder-gray-400 bg-white border border-gray-200 rounded-xl shadow-sm transition-all duration-200 focus:ring-2 focus:ring-blue-500 focus:border-transparent hover:border-gray-300"
                />
              </div>
              <div>
                <label
                  htmlFor="time"
                  className="block text-sm font-medium text-gray-700 mb-1"
                >
                  Time
                </label>
                <input
                  type="time"
                  id="time"
                  name="time"
                  value={time}
                  onChange={handleChange}
                  required
                  className="block w-full px-4 py-3 text-gray-900 placeholder-gray-400 bg-white border border-gray-200 rounded-xl shadow-sm transition-all duration-200 focus:ring-2 focus:ring-blue-500 focus:border-transparent hover:border-gray-300"
                />
              </div>
              <div>
                <label
                  htmlFor="location"
                  className="block text-sm font-medium text-gray-700 mb-1"
                >
                  Location
                </label>
                <input
                  type="text"
                  id="location"
                  name="location"
                  value={formData.location}
                  onChange={handleChange}
                  required
                  className="block w-full px-4 py-3 text-gray-900 placeholder-gray-400 bg-white border border-gray-200 rounded-xl shadow-sm transition-all duration-200 focus:ring-2 focus:ring-blue-500 focus:border-transparent hover:border-gray-300"
                  placeholder="Enter event location"
                />
              </div>
            </div>
          </div>

          {/* Event Details Section */}
          <div className="bg-gray-50 rounded-xl p-6">
            <h2 className="text-lg font-semibold text-gray-900 mb-4">
              Event Details
            </h2>
            <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
              <div>
                <label
                  htmlFor="imageUrl"
                  className="block text-sm font-medium text-gray-700 mb-1"
                >
                  Image URL
                </label>
                <input
                  type="url"
                  id="imageUrl"
                  name="imageUrl"
                  value={formData.imageUrl}
                  onChange={handleChange}
                  required
                  className="block w-full px-4 py-3 text-gray-900 placeholder-gray-400 bg-white border border-gray-200 rounded-xl shadow-sm transition-all duration-200 focus:ring-2 focus:ring-blue-500 focus:border-transparent hover:border-gray-300"
                  placeholder="Enter image URL"
                />
              </div>
              <div>
                <label
                  htmlFor="capacity"
                  className="block text-sm font-medium text-gray-700 mb-1"
                >
                  Capacity
                </label>
                <input
                  type="number"
                  id="capacity"
                  name="capacity"
                  value={formData.capacity}
                  onChange={handleChange}
                  required
                  min="1"
                  className="block w-full px-4 py-3 text-gray-900 placeholder-gray-400 bg-white border border-gray-200 rounded-xl shadow-sm transition-all duration-200 focus:ring-2 focus:ring-blue-500 focus:border-transparent hover:border-gray-300"
                  placeholder="Enter maximum attendees"
                />
              </div>
            </div>
          </div>

          {/* Action Buttons */}
          <div className="flex justify-end space-x-4">
            <button
              type="button"
              onClick={() => navigate("/dashboard/events")}
              className="inline-flex items-center px-6 py-3 border border-gray-300 text-base font-medium rounded-xl text-gray-700 bg-white hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500"
            >
              Cancel
            </button>
            <button
              type="submit"
              className="inline-flex items-center px-6 py-3 border border-transparent text-base font-medium rounded-xl text-white bg-blue-600 hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500"
            >
              <svg
                className="w-5 h-5 mr-2"
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth={2}
                  d="M5 13l4 4L19 7"
                />
              </svg>
              Save Changes
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}
