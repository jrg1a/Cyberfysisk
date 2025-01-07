%% Funksjon for å konstruere Routh-tabell
function routh_table = constructRouthTable(den)
    % Denne funksjonen konstruerer Routh-tabellen for et gitt nevnerpolynom

    % Fjern ledende nuller i nevnerpolynomet
    den = den(find(den, 1):end);
    
    % Initialiser Routh-tabellen
    n = length(den); % Antall koeffisienter
    routh_table = zeros(n, ceil(n/2));

    % Fyll de første to radene i Routh-tabellen
    routh_table(1, :) = den(1:2:end); % Oddetallsindekser
    if length(den) > 1
        routh_table(2, :) = den(2:2:end); % Partallsindekser
    end

    % Beregn de resterende radene
    for i = 3:n
        for j = 1:size(routh_table, 2)-1
            a = routh_table(i-1, 1);
            b = routh_table(i-2, 1);
            if abs(a) < 1e-6 % Håndter null i første kolonne
                a = 1e-6;
            end
            routh_table(i, j) = ((routh_table(i-1, 1) * routh_table(i-2, j+1)) - ...
                                 (routh_table(i-2, 1) * routh_table(i-1, j+1))) / a;
        end

        % Hvis raden er null, bruk spesialtilfelle
        if all(routh_table(i, :) == 0)
            order = n - i + 1;
            for k = 1:size(routh_table, 2)
                routh_table(i, k) = (order - 2 * (k - 1)) * routh_table(i-1, k);
            end
        end
    end
end
