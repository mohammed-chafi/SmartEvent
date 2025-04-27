import { Link } from "react-router-dom";
import EventList from "../components/EventList";
import { Event } from "../Interfaces/Event";

export default function Home() {
  const sampleEvents: Event[] = [
    {
      id: 1,
      title: "Tech Conference 2024",
      description:
        "Annual technology conference featuring the latest innovations",
      date: "2024-06-15",
      location: "Convention Center, New York",
      imageUrl:
        "https://images.unsplash.com/photo-1505373877841-8d25f7d46678?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1000&q=80",
      longDescription: "",
      time: "",
      category: "",
      price: 0,
      capacity: 0,
      registered: 0,
      organizer: {
        name: "",
        email: "",
      },
    },
    {
      id: 2,
      title: "Startup Networking Event",
      description: "Connect with entrepreneurs and investors",
      date: "2024-05-20",
      location: "Innovation Hub, San Francisco",
      imageUrl:
        "https://images.unsplash.com/photo-1522071820081-009f0129c71c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1000&q=80",
      longDescription: "",
      time: "",
      category: "",
      price: 0,
      capacity: 0,
      registered: 0,
      organizer: {
        name: "",
        email: "",
      },
    },
    {
      id: 3,
      title: "Digital Marketing Workshop",
      description: "Learn the latest digital marketing strategies",
      date: "2024-07-10",
      location: "Business Center, Chicago",
      imageUrl:
        "https://images.unsplash.com/photo-1511578314322-379afb476865?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1000&q=80",
      longDescription: "",
      time: "",
      category: "",
      price: 0,
      capacity: 0,
      registered: 0,
      organizer: {
        name: "",
        email: "",
      },
    },
  ];

  return (
    <div className="min-h-screen bg-white">
      {/* Hero Section */}
      <section className="relative pt-20">
        <div className="absolute inset-0">
          <img
            src="https://images.unsplash.com/photo-1511578314322-379afb476865?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2000&q=80"
            alt="Event background"
            className="w-full h-full object-cover"
          />
          <div className="absolute inset-0 bg-gradient-to-br from-blue-600/80 to-blue-800/80" />
        </div>
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 relative">
          <div className="text-center py-20">
            <h1 className="text-5xl font-bold text-white mb-6">
              Create and Manage Your Events
              <span className="text-blue-200"> with Ease</span>
            </h1>
            <p className="text-xl text-blue-100 mb-8 max-w-2xl mx-auto">
              SmartEvent helps you organize, promote, and manage your events all
              in one place. From small gatherings to large conferences, we've
              got you covered.
            </p>
            <div className="flex justify-center space-x-4">
              <Link
                to="/create"
                className="bg-white text-blue-600 px-8 py-3 rounded-full text-lg font-medium hover:bg-blue-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500 transition-all duration-200"
              >
                Create Event
              </Link>
              <Link
                to="/events"
                className="bg-transparent text-white px-8 py-3 rounded-full text-lg font-medium border-2 border-white hover:bg-white/10 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-white transition-all duration-200"
              >
                Browse Events
              </Link>
            </div>
          </div>
        </div>
      </section>

      {/* Events Section */}
      <section className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-16">
        <div className="text-center mb-16">
          <h2 className="text-3xl font-bold text-gray-900 mb-4">
            Featured Events
          </h2>
          <p className="text-xl text-gray-600">
            Explore our curated selection of upcoming events that you won't want
            to miss
          </p>
        </div>
        <EventList events={sampleEvents} />
      </section>

      {/* Features Section */}
      <section className="py-20 bg-gray-50">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="text-center mb-16">
            <h2 className="text-3xl font-bold text-gray-900 mb-4">
              Why Choose SmartEvent?
            </h2>
            <p className="text-xl text-gray-600">
              Everything you need to make your event a success
            </p>
          </div>
          <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
            <div className="bg-white p-8 rounded-2xl shadow-sm hover:shadow-md transition-all duration-200">
              <div className="bg-blue-100 w-12 h-12 rounded-lg flex items-center justify-center mb-6">
                <svg
                  className="h-6 w-6 text-blue-600"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="currentColor"
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth={2}
                    d="M12 6v6m0 0v6m0-6h6m-6 0H6"
                  />
                </svg>
              </div>
              <h3 className="text-xl font-semibold text-gray-900 mb-3">
                Easy Event Creation
              </h3>
              <p className="text-gray-600">
                Create beautiful event pages in minutes with our intuitive
                interface.
              </p>
            </div>
            <div className="bg-white p-8 rounded-2xl shadow-sm hover:shadow-md transition-all duration-200">
              <div className="bg-blue-100 w-12 h-12 rounded-lg flex items-center justify-center mb-6">
                <svg
                  className="h-6 w-6 text-blue-600"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="currentColor"
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth={2}
                    d="M17 20h5v-2a3 3 0 00-5.356-1.857M17 20H7m10 0v-2c0-.656-.126-1.283-.356-1.857M7 20H2v-2a3 3 0 015.356-1.857M7 20v-2c0-.656.126-1.283.356-1.857m0 0a5.002 5.002 0 019.288 0M15 7a3 3 0 11-6 0 3 3 0 016 0zm6 3a2 2 0 11-4 0 2 2 0 014 0zM7 10a2 2 0 11-4 0 2 2 0 014 0z"
                  />
                </svg>
              </div>
              <h3 className="text-xl font-semibold text-gray-900 mb-3">
                Manage Attendees
              </h3>
              <p className="text-gray-600">
                Keep track of registrations, send updates, and manage your guest
                list.
              </p>
            </div>
            <div className="bg-white p-8 rounded-2xl shadow-sm hover:shadow-md transition-all duration-200">
              <div className="bg-blue-100 w-12 h-12 rounded-lg flex items-center justify-center mb-6">
                <svg
                  className="h-6 w-6 text-blue-600"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="currentColor"
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth={2}
                    d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z"
                  />
                </svg>
              </div>
              <h3 className="text-xl font-semibold text-gray-900 mb-3">
                Analytics & Insights
              </h3>
              <p className="text-gray-600">
                Get detailed insights about your event's performance and
                attendee engagement.
              </p>
            </div>
          </div>
        </div>
      </section>

      {/* CTA Section */}
      <section className="py-20">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="bg-gradient-to-r from-blue-600 to-blue-800 rounded-3xl p-12 text-center">
            <h2 className="text-3xl font-bold text-white mb-6">
              Ready to Create Your Next Event?
            </h2>
            <p className="text-xl text-blue-100 mb-8 max-w-2xl mx-auto">
              Join thousands of event organizers who trust SmartEvent to make
              their events successful.
            </p>
            <Link
              to="/create"
              className="bg-white text-blue-600 px-8 py-3 rounded-full text-lg font-medium hover:bg-blue-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-white transition-all duration-200"
            >
              Get Started Now
            </Link>
          </div>
        </div>
      </section>
    </div>
  );
}
