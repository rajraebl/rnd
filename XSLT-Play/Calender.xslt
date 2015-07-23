<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>
  
  
  <xsl:variable name="startOfDay" select="/month/@start" />
  <xsl:variable name="days" select="/month/@days"></xsl:variable>


  <xsl:variable name="totalCells" select="$startOfDay + $days -1"></xsl:variable>

  <xsl:variable name="rows" select="$totalCells mod 7"></xsl:variable>

  <xsl:template match="/werwrre">

    <h1>
      <xsl:value-of select="/month/name"/>
      startOfDay <xsl:value-of select="$startOfDay"/> totalCells : <xsl:value-of select="$totalCells"/>
    </h1>

    <table border="1" bgcolor="yellow" align="center">
      <tr>
        <td>Mon</td>
        <td>tue</td>
        <td>wed</td>
        <td>thur</td>
        <td>fir</td>
        <td>sat</td>
        <td>Sun</td>
      </tr>
      <xsl:call-template name="month"></xsl:call-template>
  </table>
  </xsl:template>

  <xsl:template name="month">
    <xsl:param name="index" select="1"></xsl:param>
    <xsl:value-of select="$rows"/>
    <xsl:if test="$index &lt; $rows">
      <xsl:call-template name="week">
        <xsl:with-param name="index" select="$index">
          
        </xsl:with-param>
      </xsl:call-template>ola pola
    </xsl:if>
    
  </xsl:template>

  <xsl:template name="week">
    <xsl:param name="index" select="1"></xsl:param>
    <tr>
    <xsl:call-template name="day">
      <xsl:with-param name="index" select="$index"></xsl:with-param>
    </xsl:call-template>
    </tr>
  </xsl:template>

  <xsl:template name="day">
    <xsl:param name="index" select="1"></xsl:param>
    <xsl:param name="counter" select="1"></xsl:param>

    <xsl:choose>
      <xsl:when test="$index &lt; $startOfDay">
        <td>&gt;</td>
      </xsl:when>
      <xsl:when test="$index - $startOfDay + 1 > $days">
        <td>&lt;</td>
      </xsl:when>
      <xsl:otherwise>
        <td>
          <xsl:value-of select="4"/>
        </td>
      </xsl:otherwise>
    </xsl:choose>

    <xsl:if test="$counter &gt; $index">
      <xsl:call-template name="day">
        <xsl:with-param name="index" select="$index+1"></xsl:with-param>
        <xsl:with-param name="counter" select="$counter"></xsl:with-param>
      </xsl:call-template>
    </xsl:if>
    
  </xsl:template>

  <xsl:template name="factorial">
    <xsl:param name="n" select="1"/>
    <xsl:variable name="sum">
      <xsl:if test="$n = 1"> 1 </xsl:if>
      <xsl:if test="$n != 1">
        <xsl:call-template name="factorial">
          <xsl:with-param name="n" select="$n - 1"/>
        </xsl:call-template>
      </xsl:if>
    </xsl:variable>
    <xsl:value-of select="$sum * $n"/>
  </xsl:template>

  <xsl:template match="/">
  <xsl:call-template name ="factorial">
    <xsl:with-param name ="n" select="5">
    </xsl:with-param>
  </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
