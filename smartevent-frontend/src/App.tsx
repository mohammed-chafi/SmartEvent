import "./App.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Footer from "./components/Footer";
import NavBar from "./components/NavBar";
import Home from "./pages/Home";
import About from "./pages/About";
import DashboardLayout from "./pages/dashboard/DashboardLayout";
import DashboardEventsList from "./pages/dashboard/EventsList";
import CreateEvent from "./pages/dashboard/CreateEvent";
import EventSubscribers from "./pages/dashboard/EventSubscribers";
import EventEdit from "./pages/dashboard/EventEdit";
import Login from "./pages/auth/Login";
import Register from "./pages/auth/Register";
import MyEvents from "./pages/MyEvents";
import EventDetails from "./pages/EventDetails";
import Events from "./pages/Events";

function App() {
  return (
    <Router>
      <div className="min-h-screen flex flex-col">
        <NavBar />
        <main className="flex-grow">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/events" element={<Events />} />
            <Route path="/events/:eventId" element={<EventDetails />} />
            <Route path="/about" element={<About />} />
            <Route path="/login" element={<Login />} />
            <Route path="/signup" element={<Register />} />
            <Route path="/my-events" element={<MyEvents />} />

            {/* Dashboard Routes */}
            <Route path="/dashboard" element={<DashboardLayout />}>
              <Route index element={<DashboardEventsList />} />
              <Route path="events" element={<DashboardEventsList />} />
              <Route path="create" element={<CreateEvent />} />
              <Route
                path="events/:eventId/subscribers"
                element={<EventSubscribers />}
              />
              <Route path="events/:eventId/edit" element={<EventEdit />} />
            </Route>
          </Routes>
        </main>
        <Footer />
      </div>
    </Router>
  );
}

export default App;
