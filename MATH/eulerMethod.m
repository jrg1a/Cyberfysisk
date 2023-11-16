function [t, y] = eulerMethod(f, t0, y0, h, n)
    % f: En funksjonshåndterer for dy/dt (f(t, y))
    % t0: Startverdien for t
    % y0: Startverdien for y
    % h: Steglengde
    % n: Antall steg

    % Initialiserer vektorer for t og y
    t = t0 + (0:n-1) * h;
    y = zeros(1, n);
    y(1) = y0;

    % Eulers metode iterasjon
    for i = 1:n-1
        y(i+1) = y(i) + h * f(t(i), y(i));
    end
end


