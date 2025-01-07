function routh_table = generateRouthTable(coeffs)
    % Funksjon for å lage Routh-tabellen fra karakteristisk polynom
    % coeffs: Koeffisientene til det karakteristiske polynomet
    %
    % Eksempel: generateRouthTable([1, 2, 4, K]) for s^3 + 2s^2 + 4s + K

    % Antall rader
    n = length(coeffs);
    
    % Routh-tabellen dimensjoner
    numCols = ceil(n / 2);
    routh_table = sym(zeros(n, numCols));  % Bruk symbolsk for eksakt regning
    
    % Fyll de første to radene fra koeffisientenefunction routh_table = generateRouthTable(coeffs)
    % Funksjon for å lage Routh-tabellen fra karakteristisk polynom
    % coeffs: Koeffisientene til det karakteristiske polynomet
    %
    % Eksempel: generateRouthTable([1, 2, 4, K]) for s^3 + 2s^2 + 4s + K

    % Antall rader
    n = length(coeffs);
    
    % Routh-tabellen dimensjoner
    numCols = ceil(n / 2);
    routh_table = sym(zeros(n, numCols));  % Bruk symbolsk for eksakt regning
    
    % Fyll de første to radene fra koeffisientene
    routh_table(1, :) = coeffs(1:2:end);  % Oddetallsindekser
    if length(coeffs) > 1
        routh_table(2, 1:length(coeffs(2:2:end))) = coeffs(2:2:end);  % Partallsindekser
    end
    
    % Sett epsilon for å håndtere spesialtilfeller
    epss = 1e-6;
    
    % Generer resten av tabellen
    for i = 3:n
        for j = 1:numCols - 1
            % Beregn verdien for hver celle
            a = routh_table(i-1, 1);
            b = routh_table(i-2, j+1);
            c = routh_table(i-2, 1);
            d = routh_table(i-1, j+1);
            if a == 0
                routh_table(i, j) = epss;  % Spesialtilfelle: Null i første kolonne
            else
                routh_table(i, j) = -(c * d - b * a) / a;
            end
        end
        
        % Hvis hele raden blir null, erstatt med derivert rad
        if all(routh_table(i, :) == 0)
            order = n - i + 1;
            for k = 1:numCols - 1
                routh_table(i, k) = (order - 2*k + 2) * routh_table(i-2, k);
            end
        end
    end
    
    % Skriv ut tabellen
    fprintf('\nRouth-tabellen:\n');
    disp(routh_table);
end
    routh_table(1, :) = coeffs(1:2:end);  % Oddetallsindekser
    if length(coeffs) > 1
        routh_table(2, 1:length(coeffs(2:2:end))) = coeffs(2:2:end);  % Partallsindekser
    end
    
    % Sett epsilon for å håndtere spesialtilfeller
    epss = 1e-6;
    
    % Generer resten av tabellen
    for i = 3:n
        for j = 1:numCols - 1
            % Beregn verdien for hver celle
            a = routh_table(i-1, 1);
            b = routh_table(i-2, j+1);
            c = routh_table(i-2, 1);
            d = routh_table(i-1, j+1);
            if a == 0
                routh_table(i, j) = epss;  % Spesialtilfelle: Null i første kolonne
            else
                routh_table(i, j) = -(c * d - b * a) / a;
            end
        end
        
        % Hvis hele raden blir null, erstatt med derivert rad
        if all(routh_table(i, :) == 0)
            order = n - i + 1;
            for k = 1:numCols - 1
                routh_table(i, k) = (order - 2*k + 2) * routh_table(i-2, k);
            end
        end
    end
    
    % Skriv ut tabellen
    fprintf('\nRouth-tabellen:\n');
    disp(routh_table);
end