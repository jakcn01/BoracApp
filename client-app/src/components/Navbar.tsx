"use client";

import { useEffect, useRef, useState } from "react";
import { toast } from "sonner";

const Navbar = () => {
  const [isVisible, setIsVisible] = useState(true);
  const [isHovered, setIsHovered] = useState(false);
  const lastScrollY = useRef(0);
  const timeoutId = useRef<number | null>(null);
  const isHoveredRef = useRef(false);

  useEffect(() => {
    isHoveredRef.current = isHovered;
  }, [isHovered]);

  useEffect(() => {
    const clearTimeoutId = () => {
      if (timeoutId.current) {
        window.clearTimeout(timeoutId.current);
        timeoutId.current = null;
      }
    };

    const handleScroll = () => {
      const currentScrollY = window.scrollY;

      if (currentScrollY === 0) {
        setIsVisible(true);
        clearTimeoutId();
      } else if (
        currentScrollY > lastScrollY.current &&
        !isHoveredRef.current
      ) {
        setIsVisible(false);
        clearTimeoutId();
      } else if (
        currentScrollY < lastScrollY.current &&
        !isHoveredRef.current
      ) {
        setIsVisible(true);
        clearTimeoutId();
        timeoutId.current = window.setTimeout(() => {
          setIsVisible(false);
          timeoutId.current = null;
        }, 1000);
      }

      lastScrollY.current = currentScrollY;
    };

    window.addEventListener("scroll", handleScroll, { passive: true });
    return () => {
      window.removeEventListener("scroll", handleScroll);
      clearTimeoutId();
    };
  }, []);

  const handleHover = (hovering: boolean) => {
    setIsHovered(hovering);
    isHoveredRef.current = hovering;

    if (hovering) {
      setIsVisible(true);
      if (timeoutId.current) {
        window.clearTimeout(timeoutId.current);
        timeoutId.current = null;
      }
    } else if (window.scrollY !== 0) {
      if (timeoutId.current) {
        window.clearTimeout(timeoutId.current);
        timeoutId.current = null;
      }
      timeoutId.current = window.setTimeout(() => {
        setIsVisible(false);
        timeoutId.current = null;
      }, 1000);
    }
  };

  const scrollToSection = (id: string) => {
    const element = document.getElementById(id);
    if (!element) return;

    const headerHeight = document.querySelector("header")?.clientHeight ?? 0;
    const offsetTop =
      element.getBoundingClientRect().top + window.scrollY - headerHeight - 16;

    window.scrollTo({
      top: offsetTop,
      behavior: "smooth",
    });
  };
  const handlePesClick = () => {
    scrollToSection("pes");
    toast.success("Haf");
  };

  return (
    <header className="navbar-wrapper">
      <nav
        className={`navbar ${isVisible || isHovered ? "navbar-visible" : "navbar-hidden"}`}
        onMouseEnter={() => handleHover(true)}
        onMouseLeave={() => handleHover(false)}
      >
        <ul className="navbar-list">
          <li>
            <button className="nav-button" onClick={() => handlePesClick()}>
              Pes
            </button>
          </li>
          <li>
            <button
              className="nav-button"
              onClick={() => scrollToSection("kocka")}
            >
              Kocka
            </button>
          </li>
        </ul>
      </nav>
    </header>
  );
};

export default Navbar;
