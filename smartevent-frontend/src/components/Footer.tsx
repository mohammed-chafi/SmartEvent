export default function Footer() {
  return (
    <footer className="bg-white ">
      <div className="max-w-screen-xl p-4 py-6 mx-auto lg:py-16 md:p-8 lg:p-10">
        <hr className="my-6 border-gray-200 sm:mx-auto  lg:my-8" />
        <div className="text-center">
          <a
            href="#"
            className="flex items-center justify-center mb-5 text-2xl font-semibold text-gray-900 "
          >
            <img
              src="./images/logo.svg"
              className="h-6 mr-3 sm:h-9"
              alt="Landwind Logo"
            />
            Landwind
          </a>
          <span className="block text-sm text-center text-gray-500 ">
            © 2021-2022 Landwind™. All Rights Reserved. Built with{" "}
          </span>
        </div>
      </div>
    </footer>
  );
}
