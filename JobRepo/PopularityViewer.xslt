<?xml version="1.0"?>
<xsl:stylesheet
xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
version="1.1">
  <xsl:template match="/">
    <HTML>
      <BODY>
        <TABLE>
          <TR>
            <TD style="width=200px">Keyword</TD>
            <TD>Popularity</TD>
          </TR>
          <xsl:apply-templates />
          <!--We can use <xsl:for-each select="//KeywordPopularity"> as well-->
        </TABLE>
      </BODY>
    </HTML>
  </xsl:template>
  <xsl:template match="//KeywordPopularity">
    <!--match="KeywordPopularity" works as well-->
    <TR>
      <TD>
        <xsl:value-of select="Keyword"/>
      </TD>
      <TD>
        <xsl:apply-templates select="Count"/>
      </TD>
    </TR>
  </xsl:template>
  <xsl:template match="Count">
    <xsl:value-of select="."/>
    <!--mif we have attribute we can get its value by  <xsl:value-of select="@AttName"/>-->
  </xsl:template>
</xsl:stylesheet>