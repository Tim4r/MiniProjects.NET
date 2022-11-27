Declare @products varchar(200) = '1|20|3|343|44|6|8765'
Declare @individual varchar(20) = null

WHILE LEN(@products) > 0
BEGIN
    IF PATINDEX('%|%', @products) > 0
    BEGIN
        SET @individual = SUBSTRING(@products,
                                    0,
                                    PATINDEX('%|%', @products))
        SELECT @individual

        SET @products = SUBSTRING(@products,
                                  LEN(@individual + '|') + 1,
                                  LEN(@products))
    END
    ELSE
    BEGIN
        SET @individual = @products
        SET @products = NULL
        SELECT @individual
    END
END